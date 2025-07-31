using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.MQTTServices
{
    public class VinPublisherService
    {
        private readonly IMqttClient _client;
        private readonly MqttClientOptions _options;

        public VinPublisherService(string clientId, string host, int port)
        {
            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();

            _options = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(host, port)
                .WithCleanSession()
                .Build();
        }

        public async Task<bool> PublishVinAsync(string vin, List<string> stationIds)
        {
            var result = await _client.ConnectAsync(_options);
            if (result.ResultCode != MqttClientConnectResultCode.Success)
                return false;

            foreach (var station in stationIds)
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic($"vin/update/{station}")
                    .WithPayload(vin)
                    .WithRetainFlag(true) // giúp máy trạm nhận VIN nếu mở sau
                    .Build();

                await _client.PublishAsync(message);
            }

            await _client.DisconnectAsync();
            return true;
        }
    }

}
