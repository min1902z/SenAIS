using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            try
            {
                // Đọc các byte dữ liệu có sẵn
                while (serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[21]; // Có thể update realtime
                    //byte[] buffer = new byte[serialPort.BytesToRead];
                    //byte receivedByte = (byte)serialPort.ReadByte();
                    serialPort.Read(buffer, 0, buffer.Length);
                    dataBuffer.AddRange(buffer);

                    // Kiểm tra nếu đã nhận đủ một gói dữ liệu hoàn chỉnh
                    if (dataBuffer.Count >= 21 )
                    {
                        byte[] completeData = dataBuffer.Take(21).ToArray();

                        // Kiểm tra byte đầu tiên để đảm bảo rằng đây là một gói dữ liệu hợp lệ
                        if (completeData[0] == 0x06)
                        {
                            if (activeForm is frmGasEmission)
                            {
                                ((frmGasEmission)activeForm).ProcessNHA506Data(completeData);
                            }
                        }

                        // Xóa các byte đã xử lý khỏi buffer
                        dataBuffer.RemoveRange(0, 21);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
        //private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        //{
        //    MessageBox.Show("DataReceivedHandler");
        //    try
        //    {
        //        byte[] buffer = new byte[serialPort.BytesToRead];
        //        serialPort.Read(buffer, 0, buffer.Length);
        //        dataBuffer.AddRange(buffer);

        //        // Assume a full data packet is 10 bytes (1 start byte, 5 data bytes, 2 checksum bytes, 1 end byte)
        //        if (dataBuffer.Count >= 10 && dataBuffer[0] == 0x01 && dataBuffer[9] == 0xFF)
        //        {
        //            byte[] completeData = dataBuffer.Take(10).ToArray();

        //            // Extract the 5 bytes of sound level data
        //            byte[] soundLevelData = completeData.Skip(1).Take(5).ToArray();

        //            // Calculate the checksum (sum of the 5 data bytes)
        //            int calculatedChecksum = soundLevelData.Sum(b => (int)b);
        //            int receivedChecksum = (completeData[6] << 8) | completeData[7];

        //            // Verify checksum
        //            if (calculatedChecksum == receivedChecksum)
        //            {
        //                if (activeForm is frmNoise)
        //                {
        //                    ((frmNoise)activeForm).ProcessNoiseData(completeData);
        //                }
        //            }

        //            // Clear the buffer after processing
        //            dataBuffer.Clear();
        //        }

        //// Assume a full data packet is 21 bytes and starts with 0x06
        //if (dataBuffer.Count >= 21 && dataBuffer[0] == 0x06)
        //{
        //    byte[] completeData = dataBuffer.Take(21).ToArray();

        //    if (activeForm is frmGasEmission)
        //    {
        //        ((frmGasEmission)activeForm).ProcessNHA506Data(completeData);
        //    }
        //    else if (activeForm is frmNoise)
        //    {
        //        ((frmNoise)activeForm).ProcessNoiseData(completeData);
        //    }
        //    // Add more cases for other forms as needed

        //    // Clear the buffer after processing
        //    dataBuffer.Clear();
        //}
    //}
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Lỗi nhận dữ liệu: " + ex.Message);
    //        }
    //    }
        
        private void ProcessNHA506Data(byte[] data)
        { 
                if (data.Length >= 21 && data[0] == 0x06)
                {
                    int hcValue = (data[1] << 8) | data[2];
                    if (hcValue > 0x7FFF) hcValue -= 0x10000;

                    int coValue = (data[3] << 8) | data[4];
                    if (coValue > 0x7FFF) coValue -= 0x10000;

                    int co2Value = (data[5] << 8) | data[6];
                    if (co2Value > 0x7FFF) co2Value -= 0x10000;

                    int o2Value = (data[7] << 8) | data[8];
                    if (o2Value > 0x7FFF) o2Value -= 0x10000;

                    int noValue = (data[9] << 8) | data[10];
                    if (noValue > 0x7FFF) noValue -= 0x10000;

                int rpmValue = (data[11] << 8) | data[12];
                if (rpmValue > 0x7FFF) rpmValue -= 0x10000;

                int otValue = (data[13] << 8) | data[14];
                 if (otValue > 0x7FFF) otValue -= 0x10000;

                    if (activeForm is frmGasEmission gasEmissionForm)
                    {                       
                            gasEmissionForm.SetHCValue(hcValue.ToString());
                            gasEmissionForm.SetCOValue((coValue/100).ToString("0.00"));
                            gasEmissionForm.SetCO2Value((co2Value/100).ToString("0.00"));
                            gasEmissionForm.SetO2Value((o2Value / 100).ToString("0.00"));
                            gasEmissionForm.SetNOValue((noValue / 100).ToString("0.00"));
                    gasEmissionForm.SetRPMValue(rpmValue.ToString());
                    gasEmissionForm.SetOilTempValue(otValue.ToString());
                            
                    }
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
