using System.Threading.Tasks;

using Taller_Conexion_Gemini_Ai_Gpt.DbContext;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;

using Taller_Conexion_Gemini_Ai_Gpt.Models;
 
namespace Taller_Conexion_Gemini_Ai_Gpt.Repositories

{

    public class ChatResponseRepository : IChatResponseRepository

    {

        private readonly ApplicationDbContext _context;
 
        public ChatResponseRepository(ApplicationDbContext context)

        {

            _context = context;

        }
 
        public async Task SaveResponseAsync(ChatResponse response)

        {

            _context.ChatResponses.Add(response);

            await _context.SaveChangesAsync();

        }

    }

}
 
