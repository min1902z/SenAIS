using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SenAIS
{
    public class OPCManager
    {
        private static OPCServer opcServer;
        private static OPCGroup opcGroup;
        private static bool opcErrorShown = false;
        public static bool isConnected = false;
        public bool IsConnected => isConnected;
        private static int retryCount = 0;

        public OPCManager()
        {
            ConnectToOPCServer();
        }
        public void ConnectToOPCServer()
        {
            try
            {
                if (retryCount >= 3)
                {
                    if (!opcErrorShown)
                    {
                        MessageBox.Show("Không thể kết nối tới OPC server sau nhiều lần thử. Dừng kết nối.");
                        opcErrorShown = true;
                    }
                    return;
                }
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V6"); // Kết nối tới OPC server

                opcGroup = opcServer.OPCGroups.Add("Group1");
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 200;
                isConnected = true; // Đánh dấu kết nối thành công
                opcErrorShown = false; // Reset cờ lỗi
                retryCount = 0; // Reset lại số lần thử nếu kết nối thành công


            }
            catch (Exception ex)
            {
                isConnected = false; // Đánh dấu không kết nối được
                retryCount++; // Tăng số lần thử
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Kết nối đến OPC server thất bại: {ex.Message}");
                    opcErrorShown = true; // Đánh dấu đã hiển thị lỗi
                }
            }
        }

        public static void AddItem(string itemName, int clientHandle)
        {
            try
            {
                if (isConnected)
                {
                    opcGroup.OPCItems.AddItem(itemName, clientHandle);
                }
            }
            catch (Exception)
            {
            }
        }
        public static void DisconnectOPC()
        {
            try
            {
                if (opcServer != null && isConnected)
                {
                    // Hủy kích hoạt Group nếu cần
                    if (opcGroup != null)
                    {
                        opcGroup.IsActive = false;
                        opcGroup = null; // Giải phóng Group
                    }

                    // Ngắt kết nối OPC server
                    opcServer.Disconnect();
                    opcServer = null; // Giải phóng server
                    isConnected = false; // Đánh dấu đã ngắt kết nối
                }
            }
            catch (Exception)
            {
            }
        }
        public int GetOPCValue(string opcItem)
        {
            try
            {
                if (!isConnected)
                {
                    if (!opcErrorShown)
                    {
                        opcErrorShown = true;
                    }
                    return 0; // Giá trị mặc định
                }
                OPCItem item = opcGroup.OPCItems.AddItem(opcItem, 1);
                object value;
                item.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
                int opcValue = Convert.ToInt32(value);
                return opcValue;
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    opcErrorShown = true;
                    MessageBox.Show($"Đọc giá trị OPC item {opcItem} thất bại: {ex.Message}");
                }
                return 0; // Trả về giá trị mặc định nếu đọc thất bại
            }
        }

        public void SetOPCValue(string opcItem, int value)
        {
            try
            {
                OPCItem item = opcGroup.OPCItems.AddItem(opcItem, 1);
                item.Write(value);
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Ghi giá trị OPC item {opcItem} thất bại: {ex.Message}");
                    opcErrorShown = true;
                }
            }
        }
        public Dictionary<string, decimal> GetMultipleOPCValues(List<string> opcItems)
        {
            var result = new Dictionary<string, decimal>();

            foreach (var item in opcItems)
            {
                try
                {
                    result[item] = GetOPCValue(item);
                }
                catch
                {
                    result[item] = -1; // Trả về giá trị mặc định khi lỗi
                }
            }

            return result;
        }
    }
}
