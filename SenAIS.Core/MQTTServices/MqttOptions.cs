using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.MQTTServices
{
    public class MqttOptions
    {
        public string ClientId { get; set; }
        public string BrokerHost { get; set; }
        public int BrokerPort { get; set; } = 1883;
        public string StationId { get; set; }
    }
}
