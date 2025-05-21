using Microsoft.AspNetCore.Mvc;

namespace Taller_Conexion_Gemini_Ai_Gpt.Controllers

{

    public class ChatBotController : Controller

    {

        // Acción que devuelve la vista del ChatBot

        public IActionResult Index()

        {

            return View();

        }

    }

}
