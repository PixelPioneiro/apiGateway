namespace MqttApi.Models
{
    public class PubSub
    {
        public required string Host { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required int Port { get; set; }
        public required string Topic { get; set; }
    }
}
