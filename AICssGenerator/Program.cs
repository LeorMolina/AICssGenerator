using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using RestSharp;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AICssGenerator API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AICssGenerator API v1"));
}

app.UseCors("AllowAll");

app.MapPost("/api/generate-css", async ([FromBody] PromptRequest request, IConfiguration config) =>
{
    // Lê a chave do User Secrets (ou appsettings/variáveis de ambiente) sem a expor no código
    var apiKey = config["GroqApiKey"];

    if (string.IsNullOrEmpty(apiKey))
    {
        return Results.Problem("Chave da API da Groq não configurada no User Secrets.");
    }

    var client = new RestClient("https://api.groq.com/openai/v1/chat/completions");
    var restRequest = new RestRequest("", Method.Post);

    restRequest.AddHeader("Authorization", $"Bearer {apiKey}");
    restRequest.AddHeader("Content-Type", "application/json");

    var body = new
    {
        model = "openai/gpt-oss-120b",
        messages = new[]
        {
            new { role = "system", content = "You are an expert Frontend Developer. The user will describe a UI element. You must respond ONLY with raw, valid CSS code. No markdown formatting, no explanations, no HTML. Just the CSS." },
            new { role = "user", content = request.Prompt }
        },
        temperature = 0.2
    };

    restRequest.AddJsonBody(body);

    var response = await client.ExecuteAsync(restRequest);

    if (response.IsSuccessful)
    {
        using var jsonDoc = JsonDocument.Parse(response.Content!);
        var generatedCss = jsonDoc.RootElement
                                  .GetProperty("choices")[0]
                                  .GetProperty("message")
                                  .GetProperty("content")
                                  .GetString();

        return Results.Ok(new { css = generatedCss });
    }

    return Results.Problem($"Erro da Groq: {response.Content}");
})
.WithOpenApi();

app.Run();

public class PromptRequest
{
    public string Prompt { get; set; } = string.Empty;
}