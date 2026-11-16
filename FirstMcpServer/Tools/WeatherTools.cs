namespace FirstMcpServer.Tools;

using FirstMcpServer.Services;

using ModelContextProtocol.Server;

using System.ComponentModel;

[McpServerToolType]
public class WeatherTools
{
    private readonly WeatherService _weatherService;

    public WeatherTools(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [McpServerTool, Description("Gets the current weather for a given latitude and longitude.")]
    public Task<string> GetCurrentWeather(
        [Description("Latitude, e.g. 33.6844 for Islamabad")] double latitude,
        [Description("Longitude, e.g. 73.0479 for Islamabad")] double longitude,
        CancellationToken cancellationToken)
        => _weatherService.GetCurrentWeatherJson(latitude, longitude, cancellationToken);
}