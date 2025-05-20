using Microsoft.EntityFrameworkCore;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;
using Taller_Conexion_Gemini_Ai_Gpt.Repositories;
using Taller_Conexion_Gemini_Ai_Gpt.DbContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyecci�n de HttpClient para los repositorios
builder.Services.AddHttpClient<IGeminiRepository, GeminiRepository>();
builder.Services.AddHttpClient<IGroqRepository, GroqRepository>();

// Inyecci�n del servicio principal del chatbot
builder.Services.AddScoped<IChatBotService, ChatBotServiceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
