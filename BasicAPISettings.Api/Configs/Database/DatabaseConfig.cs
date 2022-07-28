using BasicAPISettings.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicAPISettings.Api.Configs.Database;

public static class DatabaseConfig
{
    /// <summary>
    /// Configura instância do banco de dados
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(
            builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("App"));
            });
    }
}
