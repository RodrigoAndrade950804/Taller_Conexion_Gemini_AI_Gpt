namespace Taller_Conexion_Gemini_Ai_Gpt.Interfaces
{
    public interface IGeminiRepository
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
