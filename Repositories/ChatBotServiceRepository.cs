using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;

namespace Taller_Conexion_Gemini_Ai_Gpt.Repositories
{
    public class ChatBotServiceRepository : IChatBotService
    {
        private readonly IGeminiRepository _geminiRepository;
        private readonly IGroqRepository _groqRepository;
        public ChatBotServiceRepository(IGeminiRepository geminiRepository, IGroqRepository groqRepository)
        {
            _geminiRepository = geminiRepository;
            _groqRepository = groqRepository;
        }
        public async Task<string> GetChatBotResponse(string prompt, string provider)

        {

            provider = provider.ToLower();

            if (provider == "gemini")

            {

                return await _geminiRepository.GetResponseAsync(prompt);

            }

            else if (provider == "groq")

            {

                return await _groqRepository.GetResponseAsync(prompt);

            }

            else

            {

                throw new ArgumentException("Proveedor no válido. Debe ser 'gemini' o 'groq'.");

            }

        }

    }
}
