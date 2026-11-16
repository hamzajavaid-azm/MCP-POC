namespace FirstMcpServer.Controllers;

using FirstMcpServer.Services;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] double latitude, [FromQuery] double longitude, CancellationToken cancellationToken)
    {
        var json = await _weatherService.GetCurrentWeatherJson(latitude, longitude, cancellationToken);
        return Content(json, "application/json");
    }
}
