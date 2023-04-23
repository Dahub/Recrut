using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ReCrut.Infrastructure.SqlServer.EventDatabase;

internal class EventDbContextFactory : IDesignTimeDbContextFactory<EventDbContext>
{
    public EventDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "SqlServer/EventDatabase"))
             .AddJsonFile("appsettings.json", true)
             .AddEnvironmentVariables()
             .Build();

        var builder = new DbContextOptionsBuilder<EventDbContext>();

        var connectionString = configuration
                    .GetConnectionString("EventDatabaseConnexionString");

        builder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(EventDbContextFactory).Assembly.FullName));

        return new EventDbContext(builder.Options);
    }
}
