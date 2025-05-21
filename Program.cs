using Microsoft.EntityFrameworkCore;
using Taller_Conexion_Gemini_Ai_Gpt.DbContext;
using Taller_Conexion_Gemini_Ai_Gpt.Interfaces;
using Taller_Conexion_Gemini_Ai_Gpt.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options =>

{

    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;

});


// Configuraci�n de la conexi�n a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext")));

// Agregar controladores con vistas (MVC)
builder.Services.AddControllersWithViews();

// Inyecci�n de dependencias: HttpClient para los servicios de IA
builder.Services.AddHttpClient<IGeminiRepository, GeminiRepository>();
builder.Services.AddHttpClient<IGroqRepository, GroqRepository>();

// Inyecci�n del servicio del chatbot
builder.Services.AddScoped<IChatResponseRepository, ChatResponseRepository>();

builder.Services.AddScoped<IChatBotService, ChatBotServiceRepository>();

var app = builder.Build();

// Configuraci�n del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Definici�n de rutas por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

