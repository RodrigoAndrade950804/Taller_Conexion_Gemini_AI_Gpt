using Microsoft.AspNetCore.Mvc;

using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;

using Taller_Conexion_Gemini_Ai_Gpt.Models;

[ApiController]

[Route("api/[controller]")]

public class ChatController : ControllerBase

{

    private readonly IChatBotService _chatBotService;

    private readonly IChatResponseRepository _chatResponseRepository;

    public ChatController(IChatBotService chatBotService, IChatResponseRepository chatResponseRepository)

    {

        _chatBotService = chatBotService;

        _chatResponseRepository = chatResponseRepository;

    }

    [HttpPost("enviar")]

    public async Task<IActionResult> EnviarMensaje([FromBody] ChatRequestDTO request)

    {

        var respuesta = await _chatBotService.GetChatBotResponse(request.Prompt, request.Proveedor);

        var chatResponse = new ChatResponse

        {

            Respuesta = respuesta,

            Fecha = DateTime.Now,

            Proveedor = request.Proveedor,

            GuardadoPor = request.Usuario

        };

        await _chatResponseRepository.SaveResponseAsync(chatResponse);

        return Ok(new { respuesta });

    }

}

