using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace MqttApi
{
    public class MqttBackgroundService : IHostedService
    {
        private readonly MqttClient _mqttClient;

        public MqttBackgroundService(MqttClient mqttClient)
        {
            _mqttClient = mqttClient; // Cliente MQTT injetado
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Iniciando o cliente MQTT...");
                await _mqttClient.ConnectAsync();
                _mqttClient.subscribe();
                Console.WriteLine("Cliente MQTT conectado e subscrito com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao broker MQTT: {ex.Message}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Parando o cliente MQTT...");
            return Task.CompletedTask; // Adicione lógica de desconexão aqui, se necessário
        }
    }
}
