using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ReCrut.Infrastructure.SqlServer.ProjectionDatabase;

internal class ProjectionDbContextFactory : IDesignTimeDbContextFactory<ProjectionDbContext>
{
    public ProjectionDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "SqlServer/ProjectionDatabase"))
             .AddJsonFile("appsettings.json", true)
             .AddEnvironmentVariables()
             .Build();

        var builder = new DbContextOptionsBuilder<ProjectionDbContext>();

        var connectionString = configuration
                    .GetConnectionString("EventDatabaseConnexionString");

        builder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(ProjectionDbContextFactory).Assembly.FullName));

        return new ProjectionDbContext(builder.Options);
    }
}

