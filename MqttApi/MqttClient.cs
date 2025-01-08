using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using MqttApi.Models;

namespace MqttApi
{
    public class MqttClient : IDisposable
    {
        public required PubSub data;

        private HiveMQClientOptions options = new HiveMQClientOptions();
        private HiveMQClient? client;

        public async Task InitializeAsync(PubSub data)
        {
            this.data = data;

            options.UserName = AppConfig.HmqHost;
            options.Password = AppConfig.HmqPass;
            options.Port = AppConfig.HmqPort != 0 ? AppConfig.HmqPort : 1883;
            options.Host = AppConfig.HmqHost ?? throw new InvalidOperationException("HMQ_HOST variável não setada.");

            client = new HiveMQClient(options);
            await ConnectAsync();
        }

        public async Task ConnectAsync()
        {
            if (client == null)
            {
                throw new InvalidOperationException("Client não inicializado.");
            }

            try
            {
                var connectResult = await client.ConnectAsync().ConfigureAwait(false);
                if (connectResult.SessionPresent)
                {
                    Console.WriteLine("Conectado ao broker MQTT.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao broker MQTT: {ex.Message}");
                throw;
            }
        }

        public async Task PublishAsync(string payload)
        {
            if (client == null)
            {
                throw new InvalidOperationException("Client não inicializado.");
            }

            string? topic = AppConfig.HmqTopic;
            if (string.IsNullOrEmpty(topic))
            {
                throw new InvalidOperationException("HMQ_TOPIC variável não setada.");
            }

            await client.PublishAsync(topic, payload).ConfigureAwait(false);
        }

        public void subscribe()
        {
            if (client == null)
            {
                throw new InvalidOperationException("Client não inicializado.");
            }

            string? topic = AppConfig.HmqTopic;
            if (string.IsNullOrEmpty(topic))
            {
                throw new InvalidOperationException("HMQ_TOPIC variável não setada.");
            }

            client.OnMessageReceived += (sender, args) =>
            {
                Console.WriteLine("Message Received: {}", args.PublishMessage.PayloadAsString);
            };

            client.SubscribeAsync(topic).ConfigureAwait(false);
        }

        public void Dispose()
        {
            if (client != null)
            {
                client.DisconnectAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                client.Dispose();
            }
        }
    }
}
