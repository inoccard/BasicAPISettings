using BasicAPISettings.Api.Data.Repositories;
using BasicAPISettings.Api.Domain.Repositories;

namespace BasicAPISettings.Api.Configs.Autofac;

public static class DependencyInjectionConfig
{
    public static void RegisterComponents(this IServiceCollection services)
    {
        #region Data

        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

        #endregion
    }
}
