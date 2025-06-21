using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddEcommerceCopilotKernel();

WebApplication app = builder.Build();


app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/weatherforecast", async (Kernel k) =>
{
    IChatCompletionService chatCompletionService = k.Services.GetRequiredService<IChatCompletionService>();
    ChatHistory history = new ChatHistory();
    history.AddSystemMessage("Only reply in 3 words or less");
    history.AddUserMessage("Define pi");
    PromptExecutionSettings settings = new PromptExecutionSettings { FunctionChoiceBehavior = FunctionChoiceBehavior.Auto() };
    ChatMessageContent result = await chatCompletionService.GetChatMessageContentAsync(history, settings, k);
    
    return result.Content;

})
.WithName("GetWeatherForecast");

app.MapDefaultEndpoints();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}