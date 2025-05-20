using System.Text.Json;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;
using Taller_Conexion_Gemini_Ai_Gpt.Models;

namespace Taller_Conexion_Gemini_Ai_Gpt.Repositories
{
    public class GeminiRepository : IGeminiRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "AIzaSyDB8E9B3dqGQDbRUXmaOHBlqIXoznP6nfo";

        public GeminiRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=GEMINI_API_KEY";

            var requestBody = new GeminiRequest
            {
                contents = new List<Content>
            {
                new Content
                {
                    parts = new List<Part>
                    {
                        new Part
                        {
                            text = prompt
                        }
                    }
                }
            }
            };

            var response = await _httpClient.PostAsJsonAsync(url, requestBody);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();


            var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(json);


            var responseText = geminiResponse?.candidates?[0]?.content?.parts?[0]?.text;


            return responseText?.Replace("\n", "<br>") ?? "Sin respuesta.";
        }
    }
}