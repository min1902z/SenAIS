using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS
{
    public static class OPCUtility
    {
        private static OPCServer opcServer;
        private static OPCGroup opcGroup;
        private static bool opcErrorShown = false;

        static OPCUtility()
        {
            // Kết nối tới OPC Server khi khởi tạo lớp
            ConnectToOPCServer();
        }
        private static void ConnectToOPCServer()
        {
            try
            {
                opcServer = new OPCServer();
                opcServer.Connect("Kepware.KEPServerEX.V4"); // Kết nối tới OPC server
                opcGroup = opcServer.OPCGroups.Add("Group1");
                opcGroup.IsActive = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to OPC server: {ex.Message}");
            }
        }
        public static int GetOPCValue(string opcItem)
        {
            try
            {
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
                    MessageBox.Show($"Failed to read OPC item {opcItem}: {ex.Message}");
                    opcErrorShown = true;
                }
                return 0; // Trả về giá trị mặc định nếu đọc thất bại
                //throw;
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
                    MessageBox.Show($"Failed to write to OPC item {opcItem}: {ex.Message}");
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
