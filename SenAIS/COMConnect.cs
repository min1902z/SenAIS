using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SenAIS
{
    public class COMConnect
    {
        private SerialPort serialPort;
        private Form activeForm;
        private List<byte> dataBuffer = new List<byte>();
        public bool respone47H = false;
        public COMConnect(string portName, int baudRate, Form form)
        {
            serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            activeForm = form;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public void OpenConnection()
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //while (serialPort.BytesToRead > 0) // Đảm bảo đọc hết buffer
                //{
                    byte[] buffer = new byte[serialPort.BytesToRead];
                    serialPort.Read(buffer, 0, buffer.Length);
                    dataBuffer.AddRange(buffer);
                    if (activeForm is frmDieselEmission)
                    {
                        if (dataBuffer.Count >= 9 && dataBuffer[0] == 0xA5)
                        {
                            byte[] completeData = dataBuffer.Take(9).ToArray();
                            ((frmDieselEmission)activeForm).ProcessNHT6Data(completeData);
                            // dataBuffer.RemoveRange(0, 9);
                            dataBuffer.Clear();
                        }
                        else if (dataBuffer.Count >= 7 && dataBuffer[0] == 0xA6)
                        {
                            byte[] completeData = dataBuffer.Take(7).ToArray();
                            ((frmDieselEmission)activeForm).ProcessNHT6MaxData(completeData);
                            //dataBuffer.RemoveRange(0, 7);
                            dataBuffer.Clear();
                        }
                        else // Nếu không đủ dữ liệu
                        {
                            dataBuffer.Clear(); // Xóa dữ liệu hiện tại trong buffer

                            byte[] commandA5 = { 0xA5, 0x5B };
                            byte[] commandA6 = { 0xA6, 0x5A };
                            SendRequest(commandA5);
                            //SendRequest(commandA6);
                        }
                    }
                    if (activeForm is frmGasEmission)
                    {
                        while (dataBuffer.Count >= 1 && dataBuffer[0] != 0x06)
                        {
                            dataBuffer.RemoveAt(0); // Xóa byte không hợp lệ
                        }
                        if (dataBuffer[0] == 0x06)
                        {
                            byte[] completeData = dataBuffer.Take(21).ToArray();
                            ((frmGasEmission)activeForm).ProcessNHA506Data(completeData);
                            //dataBuffer.RemoveRange(0, 21);
                            dataBuffer.Clear();
                        }
                    }

                    // Xử lý gói dữ liệu trả về từ HY114 (nếu có)
                    if (activeForm is frmNoise)
                    {
                        if (dataBuffer.Count > 0 && dataBuffer[0] == 0x06)
                        {
                            dataBuffer.RemoveAt(0);
                        }
                        if (dataBuffer.Count >= 9 && dataBuffer[0] == 0x01)
                        {
                            byte[] completeData = dataBuffer.Take(9).ToArray();
                            ((frmNoise)activeForm).ProcessNoiseData(completeData);
                            dataBuffer.RemoveRange(0, 9);
                        }
                    }
                    if (activeForm is frmWhistle)
                    {
                    while (dataBuffer.Count > 0)
                    {
                        int startIndex = dataBuffer.FindIndex(b => b == 0x01);

                        if (startIndex == -1)
                        {
                            dataBuffer.Clear();
                            break;
                        }
                        if (dataBuffer.Count >= startIndex + 6)
                        {
                            byte[] soundData = dataBuffer.Skip(startIndex).Take(6).ToArray();

                            // Xử lý dữ liệu âm thanh
                            ((frmWhistle)activeForm).ProcessMaxSoundData(soundData);

                            // Xóa các byte đã xử lý khỏi buffer
                            dataBuffer.RemoveRange(0, startIndex + 6);
                        }
                        else
                        {
                            // Nếu không đủ dữ liệu, thoát vòng lặp
                            break;
                        }
                    }
                    //if (dataBuffer.Count > 0 && dataBuffer[0] == 0x06)
                    //{
                    //    dataBuffer.RemoveAt(0);
                    //}
                    //if (dataBuffer.Count >= 9 && dataBuffer[0] == 0x01)
                    //{
                    //    byte[] completeData = dataBuffer.Take(9).ToArray();
                    //    ((frmWhistle)activeForm).ProcessMaxSoundData(completeData);
                    //    dataBuffer.RemoveRange(0, 9);
                    //}
                }
                    if (activeForm is frmHeadlights)
                    {
                        while (dataBuffer.Count > 0)
                        {
                            // Nếu phát hiện byte 0x47
                            if (dataBuffer.Contains(0x47))
                            {
                                dataBuffer.Clear();
                                byte[] request = { 0x4E, 0x4D };
                                SendRequest(request);
                            }
                            // Xử lý dữ liệu đèn (68 bytes)
                            if (dataBuffer.Count >= 68)
                            {
                                // Tìm vị trí đầu tiên của byte bắt đầu là 0x01
                                int startIndex = dataBuffer.FindIndex(b => b == 0x01);

                                if (startIndex == -1)
                                {
                                    // Nếu không tìm thấy 0x01, xóa toàn bộ buffer
                                    dataBuffer.Clear();
                                    break;
                                }

                                // Kiểm tra nếu có đủ dữ liệu từ vị trí tìm thấy
                                if (dataBuffer.Count >= startIndex + 68)
                                {
                                    // Kiểm tra cấu trúc dữ liệu hợp lệ
                                    if (dataBuffer[startIndex + 1] == 0x12 && dataBuffer[startIndex + 34] == 0x01)
                                    {
                                        // Lấy 68 byte từ vị trí hợp lệ
                                        byte[] completeData = dataBuffer.Skip(startIndex).Take(68).ToArray();

                                        // Xử lý dữ liệu với hàm ProcessNHD6109Data
                                        ((frmHeadlights)activeForm).ProcessNHD6109Data(completeData);

                                        // Xóa các byte đã xử lý khỏi buffer
                                        dataBuffer.RemoveRange(0, startIndex + 68);
                                    }
                                    else
                                    {
                                        // Nếu cấu trúc không hợp lệ, bỏ qua byte đầu tiên và tiếp tục tìm kiếm
                                        dataBuffer.RemoveAt(0);
                                    }
                                }
                                else
                                {
                                    // Nếu không đủ dữ liệu từ vị trí hợp lệ, xóa toàn bộ buffer
                                    dataBuffer.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                // Nếu không đủ dữ liệu trong buffer, thoát vòng lặp
                                break;
                            }
                        }
                    }
                //}
            }
            catch 
            {
            }
        }

        public void SendRequest(byte[] request)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(request, 0, request.Length);
            }
        }
        public bool IsConnected()
        {
            return serialPort != null && serialPort.IsOpen;
        }
    }
}
