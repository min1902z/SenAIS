using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Logging
{
    public static class Logger
    {
        private static readonly object _lock = new object();
        public static void Log(string fileName, string message)
        {
            try
            {
                // Base path: C:\Users\<UserName>\AppData\Roaming\SenAIS\Log
                string baseAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string basePath = Path.Combine(baseAppData, "SenAIS", "Log");
                //string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                DateTime now = DateTime.Now;

                string folderPath = Path.Combine(basePath,
                    now.Year.ToString(),
                    now.Month.ToString("D2"),
                    now.Day.ToString("D2"));

                Directory.CreateDirectory(folderPath);

                string fullPath = Path.Combine(folderPath, fileName);
                string timestamp = $">>> {now:yyyy-MM-dd HH:mm:ss}";
                string content = $"{timestamp}\n{message}\n-------\n";

                lock (_lock)
                {
                    // Ghi log mới lên đầu file
                    if (File.Exists(fullPath))
                    {
                        string existing = File.ReadAllText(fullPath);
                        File.WriteAllText(fullPath, content + existing);
                    }
                    else
                    {
                        File.WriteAllText(fullPath, content);
                    }
                }
            }
            catch
            {
                // Ghi log lỗi hệ thống nếu cần
            }
        }
    }
}
