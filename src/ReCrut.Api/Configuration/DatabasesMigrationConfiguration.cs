using Microsoft.EntityFrameworkCore;
using ReCrut.Infrastructure.SqlServer.EventDatabase;
using ReCrut.Infrastructure.SqlServer.ProjectionDatabase;

namespace ReCrut.Api.Configuration;

public static class DatabasesMigrationConfiguration
{
    public static WebApplication MigrateDatabases(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<EventDbContext>();
            context.Database.Migrate();
        }

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ProjectionDbContext>();
            context.Database.Migrate();
        }

        return app;
    }
}
