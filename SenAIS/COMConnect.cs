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

        public COMConnect(string portName, Form form)
        {
            serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
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
                    MessageBox.Show("Kết nối thành công. ");
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
            MessageBox.Show("DataReceivedHandler start");
            try
            {
                // Đọc các byte dữ liệu có sẵn
                while (serialPort.BytesToRead > 0)
                {
                    //byte[] buffer = new byte[21]; // Có thể update realtime
                    byte[] buffer = new byte[serialPort.BytesToRead];
                    //byte receivedByte = (byte)serialPort.ReadByte();
                    serialPort.Read(buffer, 0, buffer.Length);
                    dataBuffer.AddRange(buffer);

                    // Kiểm tra nếu đã nhận đủ một gói dữ liệu hoàn chỉnh
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
                    //    else if (completeData[0] == 0xA5) // Ki 
                    //        {
                    //            ((frmDieselEmission)activeForm).ProcessNHT6Data(completeData);
                    //        }
                    //    }
                    //    // Xóa các byte đã xử lý khỏi buffer
                    //    dataBuffer.RemoveRange(0, 21);
                    //}
                    MessageBox.Show("DataReceivedHandler");
                    string receivedData = BitConverter.ToString(buffer);
                    MessageBox.Show(receivedData);
                    if (dataBuffer.Contains(0x06))
                    {
                        MessageBox.Show("data 0x06");
                    }

                    // Xử lý gói dữ liệu trả về từ HY114 (nếu có)
                     if(dataBuffer[0] == 0x01)
                    {
                        MessageBox.Show("Data trả về 01H");
                        byte[] completeData = dataBuffer.Take(9).ToArray();

                        if (activeForm is frmNoise)
                        {
                            ((frmNoise)activeForm).ProcessNoiseData(completeData);
                        }

                        dataBuffer.RemoveRange(0, 9);
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


    }
}
