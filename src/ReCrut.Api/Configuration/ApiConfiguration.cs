using ReCrut.Application;
using ReCrut.Domain.Candidat.Commands;
using ReCrut.Domain.Candidat.Queries;

namespace ReCrut.Api.Configuration;

public static class ApiConfiguration
{
    public static WebApplication ConfigureWeb(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();

        return app;
    }

    public static WebApplication ConfigureEndpoints(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello world !"));

            endpoints.MapPost("/candidat", (CreerCandidatCommand command, CommandHandler handler) => handler.Handle(command).ToHttpResponse());
            endpoints.MapGet("/candidat", (QueryHandler handler) => handler.Handle(new GetAllCandidatsQuery()));
        });

        return app;
    }
}