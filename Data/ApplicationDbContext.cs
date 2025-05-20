using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Taller_Conexion_Gemini_Ai_Gpt.Models;

namespace Taller_Conexion_Gemini_Ai_Gpt.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ChatResponse> ChatResponses { get; set; }
    }
}
