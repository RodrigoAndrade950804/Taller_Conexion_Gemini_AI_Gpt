using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;
using Taller_Conexion_Gemini_Ai_Gpt.Models;

namespace Taller_Conexion_Gemini_Ai_Gpt.Repositories
{
    public class GeminiRepository : IGeminiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyDB8E9B3dqGQDbRUXmaOHBlqIXoznP6nfo"; // Reemplaza con tu clave real

        public GeminiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode} - {error}";
            }

            var json = await response.Content.ReadAsStringAsync();

            var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(json);

            var responseText = geminiResponse?.candidates?[0]?.content?.parts?[0]?.text;

            return responseText?.Replace("\n", "<br>") ?? "Sin respuesta.";
        }
    }
}
