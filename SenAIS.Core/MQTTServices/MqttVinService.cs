using MQTTnet.Client;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenAIS.Core.MQTTServices
{
    public class MqttVinService
    {
        private IMqttClient _client;
        private MqttOptions _options;
        private bool _isConnected;

        public event Action<string> OnVinReceived;

        public bool IsConnected => _isConnected;

        public MqttVinService(MqttOptions options)
        {
            _options = options;
            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();

            _client.ApplicationMessageReceivedAsync += async e =>
            {
                string payload = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment.ToArray());
                OnVinReceived?.Invoke(payload);
                await Task.CompletedTask;
            };

            _client.DisconnectedAsync += async e =>
            {
                _isConnected = false;

                await Task.Delay(TimeSpan.FromSeconds(3)); // đợi trước khi reconnect

                try
                {
                    await ConnectAsync(); // thử reconnect
                    await SubscribeVinAsync(); // đăng ký lại chủ đề
                }
                catch
                {
                }
            };
        }
        // Kết nối broker
        public async Task ConnectAsync()
        {
            if (_isConnected) return;

            var mqttOptions = new MqttClientOptionsBuilder()
                .WithClientId(_options.ClientId)
                .WithTcpServer(_options.BrokerHost, _options.BrokerPort)
                .WithCleanSession()
                .Build();

            _client.ApplicationMessageReceivedAsync += async e =>
            {
                string payload = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment.ToArray());
                OnVinReceived?.Invoke(payload); // Gửi VIN về cho UI
                await Task.CompletedTask;
            };

            var result = await _client.ConnectAsync(mqttOptions);
            _isConnected = result.ResultCode == MqttClientConnectResultCode.Success;
        }
        // Gửi Vin tới các topic
        public async Task PublishVinAsync(string vin, IEnumerable<string> stationIds)
        {
            if (!_isConnected) return;

            foreach (var stationId in stationIds)
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic($"vin/update/{stationId}")
                    .WithPayload(vin)
                    .WithRetainFlag(true) // Để máy trạm mở sau vẫn nhận VIN
                    .Build();

                await _client.PublishAsync(message);
            }
        }
        // Lấy vin từ Subcribe
        public async Task SubscribeVinAsync(string stationId = null)
        {
            if (!_isConnected) return;

            string topic = $"vin/update/{stationId ?? _options.StationId}";
            await _client.SubscribeAsync(new MqttTopicFilterBuilder()
                .WithTopic(topic)
                .Build());
        }
        // Ngắt kết nối
        public async Task DisconnectAsync()
        {
            if (_isConnected)
            {
                await _client.DisconnectAsync();
                _isConnected = false;
            }
        }
    }
}
