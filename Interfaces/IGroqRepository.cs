namespace Taller_Conexion_Gemini_Ai_Gpt.Interfaces
{
    public interface IGroqRepository
    {
        Task<string> GetResponseAsync(string prompt);
    }
}
