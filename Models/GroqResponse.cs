namespace Taller_Conexion_Gemini_Ai_Gpt.Models
{
    public class GroqResponse
    {
        public List<Choice> choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }
}
