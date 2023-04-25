using ReCrut.Application;
using ReCrut.Domain.Candidat.Commands;

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
        });

        return app;
    }
}