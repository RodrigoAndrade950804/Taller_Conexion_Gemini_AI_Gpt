using System.Collections.Generic;
namespace Taller_Conexion_Gemini_Ai_Gpt.Models
{
    public class GeminiResponse
    {
        public List<Candidate> candidates { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
    }
}
