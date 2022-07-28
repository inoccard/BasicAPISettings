using BasicAPISettings.Api.Data.Repositories.Base;
using BasicAPISettings.Api.Domain.Models.WeatherForecastAggregate.Entities;
using BasicAPISettings.Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicAPISettings.Api.Data.Repositories
{
    public class WeatherForecastRepository : GenericRepository<WeatherForecast>, IWeatherForecastRepository
    {
        private readonly DbSet<WeatherForecast> _dbSet;

        public WeatherForecastRepository(DataContext context) : base(context)
        {
            _dbSet = context.Set<WeatherForecast>();
        }
    }
}
