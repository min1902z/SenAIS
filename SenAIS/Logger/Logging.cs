using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SenAIS.Logger
{
    public static class Logging
    {
        private static readonly string BaseLogPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "SenAISLogs" 
        );

        public static void LogError(object sender, Exception ex)
        {
            string formName = sender?.GetType().Name ?? "UnknownForm";
            string methodName = GetCallingMethod();
            WriteLog(formName, $"[{methodName}] {ex}");
        }

        public static void LogError(object sender, string message)
        {
            string formName = sender?.GetType().Name ?? "UnknownForm";
            string methodName = GetCallingMethod();
            WriteLog(formName, $"[{methodName}] {message}");
        }

        private static void WriteLog(string formName, string message)
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                string month = DateTime.Now.Month.ToString("D2");
                string day = DateTime.Now.Day.ToString("D2");

                string logDir = Path.Combine(BaseLogPath, year, month, day);
                Directory.CreateDirectory(logDir);

                string logFilePath = Path.Combine(logDir, $"{formName}.log");
                string logEntry = $">>> {DateTime.Now:yyyy/MM/dd HH:mm:ss}:\n{message}\n\n";

                if (File.Exists(logFilePath))
                {
                    string oldContent = File.ReadAllText(logFilePath, Encoding.UTF8);
                    File.WriteAllText(logFilePath, logEntry + oldContent, Encoding.UTF8);
                }
                else
                {
                    File.WriteAllText(logFilePath, logEntry, Encoding.UTF8);
                }
            }
            catch
            {
                // Không để lỗi log làm crash chương trình
            }
        }

        private static string GetCallingMethod()
        {
            try
            {
                var stack = new StackTrace();
                var frame = stack.GetFrame(3);
                var method = frame?.GetMethod();
                return method != null
                    ? $"{method.DeclaringType?.Name}.{method.Name}"
                    : "UnknownMethod";
            }
            catch
            {
                return "UnknownMethod";
            }
        }
    }
}
