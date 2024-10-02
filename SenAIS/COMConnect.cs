using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SenAIS
{
    public class COMConnect
    {
        private SerialPort serialPort;
        private Form activeForm;
        private List<byte> dataBuffer = new List<byte>();
        private bool requestA5Completed = false;
        public COMConnect(string portName, Form form)
        {
            serialPort = new SerialPort(portName, 300, Parity.None, 8, StopBits.One);
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
                    else if(dataBuffer.Count >= 7 && dataBuffer[0] == 0xA6)
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

                    //if (dataBuffer.Count >= 21)
                    //{
                    //    byte[] completeData = dataBuffer.Take(21).ToArray();

                    //    // Kiểm tra byte đầu tiên để đảm bảo rằng đây là một gói dữ liệu hợp lệ
                    //    if (completeData[0] == 0x06)
                    //    {
                    //        if (activeForm is frmGasEmission)
                    //        {
                    //            ((frmGasEmission)activeForm).ProcessNHA506Data(completeData);
                    //        }
                    //    }
                    //    // Xóa các byte đã xử lý khỏi buffer
                    //    dataBuffer.RemoveRange(0, 21);
                    //}

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

                    //if (dataBuffer.Count >= 21 && dataBuffer[0] == 0x4D) // Assume 0x4D is the start byte for NHD6109 data
                    //{
                    //    byte[] completeData = dataBuffer.Take(21).ToArray();
                    //    dataBuffer.RemoveRange(0, 21);

                    //    if (activeForm is frmCosLightL)
                    //    {
                    //        ((frmCosLightL)activeForm).ProcessNHD6109Data(completeData);
                    //    }
                    //    else if (activeForm is frmCosLightR)
                    //    {
                    //        ((frmCosLightR)activeForm).ProcessNHD6109Data(completeData);
                    //    }
                    //    else if (activeForm is frmHeadLightL)
                    //    {
                    //        ((frmHeadLightL)activeForm).ProcessNHD6109Data(completeData);
                    //    }
                    //    else if (activeForm is frmHeadLightR)
                    //    {
                    //        ((frmHeadLightR)activeForm).ProcessNHD6109Data(completeData);
                    //    }
                    //}
                    //}
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
    }
}
