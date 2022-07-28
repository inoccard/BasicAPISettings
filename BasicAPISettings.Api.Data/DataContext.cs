using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BasicAPISettings.Api.Data
{
    public class DataContext : DbContext
    {
        private readonly ILoggerFactory _logger = new LoggerFactory(); //Create(p => p.AddConsole());

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

            foreach (var property in properties)
                property.SetColumnType("nvarchar(250)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(c => c.Log((RelationalEventId.CommandExecuting, LogLevel.Debug)));
            optionsBuilder.UseLoggerFactory(_logger);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}