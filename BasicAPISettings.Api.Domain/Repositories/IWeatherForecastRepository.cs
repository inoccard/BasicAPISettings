using BasicAPISettings.Api.Domain.Models.WeatherForecastAggregate.Entities;

namespace BasicAPISettings.Api.Domain.Repositories;

public interface IWeatherForecastRepository : IGenericRepository<WeatherForecast>
{
}
