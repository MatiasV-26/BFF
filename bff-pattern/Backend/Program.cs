var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/weather forecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)), 
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    Console.WriteLine(String.Join(", ", (IEnumerable<WeatherForecast>) forecast));
        return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int tempC, string? Summary){
    public int TempF => 32 + (int)(tempC / 0.5556);
}
