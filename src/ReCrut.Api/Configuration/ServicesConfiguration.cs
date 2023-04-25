using Microsoft.EntityFrameworkCore;
using ReCrut.Application.Abstractions;
using ReCrut.Application;
using ReCrut.Domain.Abstractions;
using ReCrut.Infrastructure.SqlServer.EventDatabase;
using ReCrut.Infrastructure;
using ReCrut.Infrastructure.SqlServer.ProjectionDatabase;
using ReCrut.Application.ProjectionHandlers;

namespace ReCrut.Api.Configuration;

public static class ServicesConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();

        var eventDbConnectionString = builder.Configuration.GetConnectionString("EventDatabaseConnexionString");
        builder.Services.AddDbContext<EventDbContext>(c => c.UseSqlServer(eventDbConnectionString));

        var projectionDbConnectionString = builder.Configuration.GetConnectionString("ProjectionDatabaseConnexionString");
        builder.Services.AddDbContext<ProjectionDbContext>(c => c.UseSqlServer(projectionDbConnectionString));        


        builder.Services.AddSeq(builder.Configuration, builder.Environment.EnvironmentName);
        builder.Services.AddScoped<IEventPublisher, EventPublisher>();
        builder.Services.AddScoped<IEventRepository, SqlServerEventRepository>();
        builder.Services.AddScoped<IProjectionRepository, SqlServerProjectionRepository>();
        builder.Services.AddScoped<CandidatProjectionHandler>();
        builder.Services.AddScoped<IStateRepository, FromEventStateRepository>();
        builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        builder.Services.AddScoped<CommandHandler>();

        return builder;
    }
}
