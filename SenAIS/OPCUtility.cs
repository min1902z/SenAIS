using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SenAIS
{
    public class OPCUtility
    {
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private bool opcErrorShown = false;
        private bool isConnected = false;
        private int retryCount = 0;
        private Dictionary<string, OPCItem> opcItemCache = new Dictionary<string, OPCItem>();
        public OPCUtility()
        {
            ConnectToOPCServer();
        }
        private void ConnectToOPCServer()
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
        public void AddItem(string itemName, int clientHandle)
        {
            try
            {
                if (isConnected)
                {
                    opcGroup.OPCItems.AddItem(itemName, clientHandle);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding OPC item {itemName}: {ex.Message}");
            }
        }
        public void DisconnectOPC()
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
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối OPC: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Không thể kết nối tới OPC server. Sử dụng giá trị mặc định.");
                    }
                    return 0; // Giá trị mặc định
                }
                //OPCItem item = opcGroup.OPCItems.AddItem(opcItem, 1);
                //object value;
                //item.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
                //int opcValue = Convert.ToInt32(value);
                //return opcValue;
                if (!opcItemCache.ContainsKey(opcItem))
                    InitializeOPCItems(new List<string> { opcItem });

                if (!opcItemCache.TryGetValue(opcItem, out OPCItem item))
                    return 0;
                item.Read((short)OPCDataSource.OPCDevice, out object value, out _, out _);
                return Convert.ToInt32(value);
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
                //throw;
            }
        }
        public Dictionary<string, decimal> GetMultipleOPCValues(List<string> opcItems)
        {
            var result = new Dictionary<string, decimal>();
            InitializeOPCItems(opcItems);
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
        public void InitializeOPCItems(List<string> itemNames)
        {
            foreach (var name in itemNames)
            {
                if (!opcItemCache.ContainsKey(name))
                {
                    try
                    {
                        OPCItem item = opcGroup.OPCItems.AddItem(name, 1);
                        opcItemCache[name] = item;
                    }
                    catch (Exception ex)
                    {
                        // Ghi log nếu cần
                    }
                }
            }
        }

    }
}
