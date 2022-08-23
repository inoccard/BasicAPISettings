using BasicAPISettings.Api.Domain.Models.WeatherForecastAggregate.Entities;
using BasicAPISettings.Api.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicAPISettings.Api.Controllers;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/weather-forecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastRepository _repository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IEnumerable<WeatherForecast>))]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// obtém um WeatherForecast
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(WeatherForecast))]
    [HttpGet("{id}")]
    public async Task<WeatherForecast> Get(long id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
