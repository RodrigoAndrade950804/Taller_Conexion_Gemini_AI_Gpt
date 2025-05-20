using System.Collections.Generic;

namespace Taller_Conexion_Gemini_Ai_Gpt.Models
{
    public class GroqRequest
    {
        public string model { get; set; } = "llama-3.3-70b-versatile";
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public string role { get; set; }  // "user" o "assistant"
        public string content { get; set; }
    }
}
