using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SenAIS
{
    public class OPCUtility
    {
        private OPCServer opcServer;
        private OPCGroup opcGroup;
        private bool opcErrorShown = false;
        private bool isConnecting = false;
        private bool isConnected = false;
        public bool IsConnected => isConnected;
        private const string serverName = "Kepware.KEPServerEX.V6";
        private const string groupName = "Group1";
        private Dictionary<string, OPCItem> addedItems = new Dictionary<string, OPCItem>();

        public OPCUtility()
        {
            TryConnectWithRetry();
        }
        private void TryConnectWithRetry()
        {
            int retries = 3;
            for (int i = 0; i < retries; i++)
            {
                ConnectToOPCServer();
                if (isConnected) break;
                Thread.Sleep(3000); // Delay 3 giây
            }

            if (!isConnected && !opcErrorShown)
            {
                MessageBox.Show("Không thể kết nối OPC server sau 3 lần thử.", "Lỗi OPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                opcErrorShown = true;
            }
        }
        public void ConnectToOPCServer()
        {
            if (isConnected || isConnecting)
                return;

            isConnecting = true;

            try
            {
                opcServer = new OPCServer();
                opcServer.Connect(serverName);
                opcGroup = opcServer.OPCGroups.Add(groupName);
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 200;

                isConnected = true;
                opcErrorShown = false;
                addedItems.Clear(); // reset OPCItems
            }
            catch (Exception ex)
            {
                isConnected = false;
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Không thể kết nối OPC server: {ex.Message}", "Lỗi OPC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    opcErrorShown = true;
                }
            }
            finally
            {
                isConnecting = false;
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
            catch (Exception)
            {
            }
        }
        public void DisconnectOPC()
        {
            try
            {
                if (opcGroup != null)
                {
                    opcGroup.IsActive = false;
                    opcGroup = null;
                }

                if (opcServer != null)
                {
                    opcServer.Disconnect();
                    opcServer = null;
                }

                isConnected = false;
                addedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ngắt kết nối OPC: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private OPCItem GetOrAddItem(string itemName, int clientHandle = 1)
        {
            if (!isConnected)
            {
                TryConnectWithRetry();
                if (!isConnected) throw new Exception("Chưa kết nối được OPC.");
            }

            if (!addedItems.ContainsKey(itemName))
            {
                try
                {
                    var item = opcGroup.OPCItems.AddItem(itemName, clientHandle);
                    addedItems[itemName] = item;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Không thêm được OPC item {itemName}: {ex.Message}");
                }
            }
            return addedItems[itemName];
        }
        public int GetOPCValue(string opcItem)
        {
            try
            {
                var item = GetOrAddItem(opcItem);
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
                return 0; // Giá trị mặc định
            }
        }
        public void SetOPCValue(string opcItem, int value)
        {
            try
            {
                var item = GetOrAddItem(opcItem);
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
