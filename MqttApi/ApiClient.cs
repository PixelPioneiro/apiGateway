using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MqttApi
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task SendDataAsync(string apiUrl, string payload)
        {
            try
            {
                if (string.IsNullOrEmpty(apiUrl))
                {
                    throw new ArgumentException("A URL da API não pode ser nula ou vazia.");
                }

                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Dados enviados com sucesso para a API.");
                }
                else
                {
                    Console.WriteLine($"Falha ao enviar dados. StatusCode: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar dados para a API: {ex.Message}");
            }
        }
    }
}

