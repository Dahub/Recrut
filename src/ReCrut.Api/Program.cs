namespace ReCrut.Api;

public class Program
{
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();
        builder.ConfigureServices();

        var app = builder.Build();

        app.MigrateDatabases();
        app.ConfigureWeb();
        app.ConfigureEndpoints();

        app.Logger.LogInformation("Start Application - Environnement : {environnement}", builder.Environment.EnvironmentName);
        
        app.Run();
    }
}