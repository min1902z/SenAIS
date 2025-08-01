using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.Config
{
    public class AppSettingsHelper
    {
        public static string GetServerHost() =>
        ConfigurationManager.AppSettings["ServerHost"];

        public static int GetServerPort() =>
            int.Parse(ConfigurationManager.AppSettings["ServerPort"]);

        public static string GetDatabaseConnectionString()
        {
            var server = GetServerHost();
            var port = ConfigurationManager.AppSettings["DbPort"];
            var db = ConfigurationManager.AppSettings["DbName"];
            var user = ConfigurationManager.AppSettings["DbUser"];
            var pass = ConfigurationManager.AppSettings["DbPassword"];

            string innerConnStr = $"Server={server},{port};Database={db};User Id={user};Password={pass};";

            return "metadata=res://*/SenAisModel.csdl|res://*/SenAisModel.ssdl|res://*/SenAisModel.msl;" +
                   $"provider=System.Data.SqlClient;provider connection string=\"{innerConnStr}\"";
        }
    }
}
