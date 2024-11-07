using OPCAutomation;
using System;
using System.Windows.Forms;

namespace SenAIS
{
    public static class OPCUtility
    {
        private static OPCServer opcServer;
        private static OPCGroup opcGroup;
        private static bool opcErrorShown = false;
        private static bool isConnected = false;
        private static int retryCount = 0;
        private static int maxRetry = 3;

        static OPCUtility()
        {
            // Kết nối tới OPC Server khi khởi tạo lớp
            ConnectToOPCServer();
        }
        private static void ConnectToOPCServer()
        {
            try
            {
                if (retryCount >= maxRetry)
                {
                    if (!opcErrorShown)
                    {
                        MessageBox.Show("Không thể kết nối tới OPC server sau nhiều lần thử. Dừng kết nối.");
                        opcErrorShown = true;
                    }
                    return;
                }
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V4"); // Kết nối tới OPC server
                opcGroup = opcServer.OPCGroups.Add("Group1");
                opcGroup.IsActive = true;
                opcGroup.IsSubscribed = true;
                opcGroup.UpdateRate = 1000;
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
        public static int GetOPCValue(string opcItem)
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

        public static void SetOPCValue(string opcItem, int value)
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
        public static void ResetErrorFlag()
        {
            opcErrorShown = false; // Reset cờ lỗi để có thể hiển thị lại lỗi nếu cần thiết
        }
    }
}
