using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EnergyController : ControllerBase
{
    private readonly IEnergyService _service;

    public EnergyController(IEnergyService service)
    {
        _service = service;
    }

    [HttpGet("consumption")]
    public async Task<IActionResult> GetConsumption([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var data = await _service.GetConsumptionAsync(page, pageSize);
        return Ok(data);
    }

    [HttpPost("data")]
    public async Task<IActionResult> PostData([FromBody] EnergyData data)
    {
        await _service.InsertDataAsync(data);
        return Ok();
    }

    [HttpGet("alerts")]
    public async Task<IActionResult> GetAlerts()
    {
        var alerts = await _service.GetAlertsAsync();
        return Ok(alerts);
    }

    [HttpGet("forecast")]
    public IActionResult GetForecast()
    {
        var forecast = _service.ForecastConsumption();
        return Ok(forecast);
    }
}