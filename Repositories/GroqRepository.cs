using System.Text.Json;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;

namespace Taller_Conexion_Gemini_Ai_Gpt.Repositories
{
    public class GroqRepository : IGroqRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "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";

        public GroqRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            string url = "https://api.groq.com/openai/v1/chat/completions";


            var requestBody = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                new { role = "user", content = prompt }
            }
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var content = doc.RootElement
                             .GetProperty("choices")[0]
                             .GetProperty("message")
                             .GetProperty("content")
                             .GetString();

            return content ?? "Sin respuesta.";
        }
    }
}
