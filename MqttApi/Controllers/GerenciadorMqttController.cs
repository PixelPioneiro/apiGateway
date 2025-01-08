using Microsoft.AspNetCore.Mvc;

namespace MqttApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GerenciadorMqttController : ControllerBase
    {
        // Exemplo de endpoint GET
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { Status = "MQTT Client Running", Timestamp = DateTime.UtcNow });
        }

        // Exemplo de endpoint POST
        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] object payload)
        {
            // Processar o payload recebido e retornar um status
            return Ok(new { Message = "Payload recebido com sucesso", Payload = payload });
        }
    }
}