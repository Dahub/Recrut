using ReCrut.Api.Configuration;

namespace ReCrut.Api.Configuration;

public static class LoggingConfiguration
{
    public static IServiceCollection AddSeq(
            this IServiceCollection services,
            IConfiguration configuration,
            string environnement) =>
        environnement switch
        {
            "Local" => UseSeq(services, configuration),
            _ => services
        };

    private static IServiceCollection UseSeq(IServiceCollection services, IConfiguration configuration) =>
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddSeq(configuration.GetSection("Seq"));
        });
}