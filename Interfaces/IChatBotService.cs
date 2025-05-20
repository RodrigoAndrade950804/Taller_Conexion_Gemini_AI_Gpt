namespace Taller_Conexion_Gemini_Ai_Gpt.Interfaces
{
    public interface IChatBotService
    {
        Task<string> GetChatBotResponse(string prompt, string provider);
    }
}
