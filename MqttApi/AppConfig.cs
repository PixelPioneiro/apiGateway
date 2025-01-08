namespace MqttApi
{
    public static class AppConfig
    {
        public static string HmqHost => Environment.GetEnvironmentVariable("HMQ_HOST")
            ?? throw new InvalidOperationException("HMQ_HOST não configurada.");
        public static string HmqTopic => Environment.GetEnvironmentVariable("HMQ_TOPIC")
            ?? throw new InvalidOperationException("HMQ_TOPIC não configurada.");
        public static int HmqPort => int.Parse(Environment.GetEnvironmentVariable("HMQ_PORT") ?? "1883");
        public static string HmqUser => Environment.GetEnvironmentVariable("HMQ_USERNAME") ?? string.Empty;
        public static string HmqPass => Environment.GetEnvironmentVariable("HMQ_PASS") ?? string.Empty;
        public static string ApiUrl => Environment.GetEnvironmentVariable("API_URL")
            ?? throw new InvalidOperationException("API_URL não configurada.");
    }
}
