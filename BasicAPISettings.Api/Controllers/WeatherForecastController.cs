using BasicAPISettings.Api.Domain.Models.WeatherForecastAggregate.Entities;
using BasicAPISettings.Api.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BasicAPISettings.Api.Controllers;

//[Authorize]
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/weather-forecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastRepository _repository;

    public WeatherForecastController(IWeatherForecastRepository repository)
    {
        _repository = repository;
    }

    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IEnumerable<WeatherForecast>))]
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var weatherForecasts = await _repository.GetAll();

        if (weatherForecasts is not null || weatherForecasts?.Length == 0)
            return Ok(weatherForecasts);
        else
            return BadRequest("Nenhum dado foi encontrado!");
    }

    /// <summary>
    /// obtém um WeatherForecast
    /// </summary>
    /// <returns></returns>
    [SwaggerResponse(StatusCodes.Status200OK, "", typeof(WeatherForecast))]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _repository.GetByIdAsync(id));
    }
}
