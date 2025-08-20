using CotizadorAC.Data;
using CotizadorAC.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);




// Configurar DbContext con MySQL (Pomelo)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<CotizadorService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); 
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization(); // Descomenta si usas auth
 app.MapControllers();   // Descomenta si usas controladores

app.Run();
