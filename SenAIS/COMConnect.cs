using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
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
                    // Tìm vị trí byte đầu tiên là A5 hoặc A6
                    int startIndexA5 = dataBuffer.IndexOf(0xA5);
                    int startIndexA6 = dataBuffer.IndexOf(0xA6);
                    if (startIndexA5 != -1 && dataBuffer.Count >= startIndexA5 + 9)
                    {
                        // Xử lý dữ liệu A5 (9 bytes)
                        byte[] completeData = dataBuffer.Skip(startIndexA5).Take(9).ToArray();
                        ((frmDieselEmission)activeForm).ProcessNHT6Data(completeData);
                        dataBuffer.RemoveRange(startIndexA5, 9);
                        byte[] commandA6 = { 0xA6, 0x5A };
                        SendRequest(commandA6);
                    }
                    else if (startIndexA6 != -1 && dataBuffer.Count >= startIndexA6 + 7)
                    {
                        // Xử lý dữ liệu A6 (7 bytes)
                        byte[] completeData = dataBuffer.Skip(startIndexA6).Take(7).ToArray();
                        ((frmDieselEmission)activeForm).ProcessNHT6MaxData(completeData);
                        dataBuffer.RemoveRange(startIndexA6, 7);
                        byte[] commandA5 = { 0xA5, 0xB5 };
                        SendRequest(commandA5);

                    }
                    else
                    {
                        dataBuffer.Clear(); // Xóa dữ liệu hiện tại trong buffer
                        byte[] commandA5 = { 0xA5, 0x5B };
                        SendRequest(commandA5);
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
                    while (dataBuffer.Count > 0)
                    {
                        int startIndex = dataBuffer.FindIndex(b => b == 0x01);

                        if (startIndex == -1)
                        {
                            dataBuffer.Clear(); // Nếu không tìm thấy 0x01, xóa toàn bộ buffer
                            break;
                        }

                        if (dataBuffer.Count >= startIndex + 6) // Đảm bảo đủ 6 byte dữ liệu
                        {
                            byte[] soundData = dataBuffer.Skip(startIndex).Take(6).ToArray();

                            // Xử lý dữ liệu âm thanh
                            ((frmNoise)activeForm).ProcessNoiseData(soundData);

                            // Xóa dữ liệu đã xử lý khỏi buffer
                            dataBuffer.RemoveRange(0, startIndex + 6);

                            // Gửi request 0xB8 ngay sau khi xử lý xong dữ liệu
                            byte[] startCommand = { 0xB8 };
                            SendRequest(startCommand);
                        }
                        else
                        {
                            break; // Nếu không đủ dữ liệu, thoát vòng lặp
                        }
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
                            // Gửi request 0xB8 ngay sau khi xử lý xong dữ liệu
                            byte[] startCommand = { 0xB8 };
                            SendRequest(startCommand);
                        }
                        else
                        {
                            // Nếu không đủ dữ liệu, thoát vòng lặp
                            break;
                        }
                    }
                }
                if (activeForm is frmHeadlights)
                {
                    string logFilePath = "headlights_data.log";  // File log

                    // Ghi log toàn bộ dataBuffer vào file
                    File.AppendAllText(logFilePath, $"{DateTime.Now}: Received DataBuffer - {BitConverter.ToString(dataBuffer.ToArray())}{Environment.NewLine}");
                    while (dataBuffer.Count > 0)
                    {
                        // Nếu phát hiện byte 0x47
                        if (dataBuffer.Contains(0x47))
                        {
                            dataBuffer.Clear();
                            //byte[] request = { 0x4E, 0x4D };
                            byte[] request = { 0x79, 0x7A };
                            SendRequest(request);
                        }
                        // Xử lý dữ liệu đèn (68 bytes)
                        if (dataBuffer.Count >= 84)
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
                            if (dataBuffer.Count >= startIndex + 86)
                            {
                                // Kiểm tra cấu trúc dữ liệu hợp lệ
                                if (dataBuffer[startIndex + 1] == 0x12 && dataBuffer[startIndex + 43] == 0x01)
                                {
                                    // Lấy 68 byte từ vị trí hợp lệ
                                    byte[] completeData = dataBuffer.Skip(startIndex).Take(86).ToArray();

                                    // Xử lý dữ liệu với hàm ProcessNHD6109Data
                                    ((frmHeadlights)activeForm).ProcessNHD6109Data(completeData);

                                    // Xóa các byte đã xử lý khỏi buffer
                                    dataBuffer.RemoveRange(0, startIndex + 86);
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
                if (activeForm is frmFogLights)
                {
                    string logFilePath = "headlights_data.log";  // File log

                    // Ghi log toàn bộ dataBuffer vào file
                    File.AppendAllText(logFilePath, $"{DateTime.Now}: Received DataBuffer - {BitConverter.ToString(dataBuffer.ToArray())}{Environment.NewLine}");
                    while (dataBuffer.Count > 0)
                    {
                        // Nếu phát hiện byte 0x47
                        if (dataBuffer.Contains(0x47))
                        {
                            dataBuffer.Clear();
                            byte[] request = { 0x79, 0x7A };
                            SendRequest(request);
                        }
                        if (dataBuffer.Count >= 84)
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
                            if (dataBuffer.Count >= startIndex + 86)
                            {
                                // Kiểm tra cấu trúc dữ liệu hợp lệ
                                if (dataBuffer[startIndex + 1] == 0x12 && dataBuffer[startIndex + 43] == 0x01)
                                {
                                    byte[] completeData = dataBuffer.Skip(startIndex).Take(86).ToArray();
                                    // Xử lý dữ liệu với hàm ProcessNHD6109Data
                                    ((frmFogLights)activeForm).ProcessNHD6109Data(completeData);
                                    // Xóa các byte đã xử lý khỏi buffer
                                    dataBuffer.RemoveRange(0, startIndex + 86);
                                }
                                else
                                {
                                    dataBuffer.RemoveAt(0);
                                }
                            }
                            else
                            {
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
