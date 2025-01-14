using System;
using System.Collections.Generic;
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
                // Đọc các byte dữ liệu có sẵn
                while (serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[serialPort.BytesToRead];
                    serialPort.Read(buffer, 0, buffer.Length);
                    dataBuffer.AddRange(buffer);
                    string receivedData = BitConverter.ToString(buffer);
                    Console.WriteLine("Received (Hex): " + receivedData);
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
                        if (dataBuffer.Count >= 21 && dataBuffer[0] == 0x06)
                        {
                            byte[] completeData = dataBuffer.Take(21).ToArray();
                            ((frmGasEmission)activeForm).ProcessNHA506Data(completeData);
                            dataBuffer.RemoveRange(0, 21);
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
                        if (dataBuffer.Count > 0 && dataBuffer[0] == 0x06)
                        {
                            dataBuffer.RemoveAt(0);
                        }
                        if (dataBuffer.Count >= 9 && dataBuffer[0] == 0x01)
                        {
                            byte[] completeData = dataBuffer.Take(9).ToArray();
                            ((frmWhistle)activeForm).ProcessMaxSoundData(completeData);
                            dataBuffer.RemoveRange(0, 9);
                        }
                    }
                    if (activeForm is frmHeadlights)
                    {
                        if (dataBuffer.Contains(0x47))
                        {
                            respone47H = true;
                        }
                        if (dataBuffer.Count >= 68 && dataBuffer[0] == 0x01 && dataBuffer[1] == 0x12 && dataBuffer[34] == 0x01)
                        {
                            byte[] completeData = dataBuffer.Take(68).ToArray();
                            ((frmHeadlights)activeForm).ProcessNHD6109Data(completeData);
                            dataBuffer.RemoveRange(0, 68);
                        }
                        else
                            dataBuffer.RemoveAt(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
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
