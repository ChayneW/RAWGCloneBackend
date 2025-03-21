using DotNetEnv;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
// builder.WebHost.UseUrls($"https://*:{port}");

// builder.Services.AddHealthChecks();

// Load environment variables from .env file
Env.Load();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient with the DI container
builder.Services.AddHttpClient();

// Add CORS policy to allow the Next.js frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        // policy.WithOrigins("http://localhost:3000", "https://rawg-clone-frontend.vercel.app") // Use the production URL
        policy.WithOrigins("http://localhost:3000", "https://rawg-clone-frontend.vercel.app" ,"https://gamevault-ten.vercel.app") // Use the production URL
            .AllowAnyHeader()  // Allow any headers
            .AllowAnyMethod(); // Allow any HTTP methods (GET, POST, PUT, etc.)
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHealthChecks("/health");

// Apply the CORS middleware before the controllers
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
