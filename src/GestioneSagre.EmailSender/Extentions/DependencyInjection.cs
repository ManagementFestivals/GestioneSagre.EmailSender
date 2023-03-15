using GestioneSagre.Logger.Extensions;

namespace GestioneSagre.EmailSender.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddEmailSenderService(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<ILoggerService, LoggerService>();

        services
            .AddSingleton<IEmailSender, MailKitEmailSender>()
            .AddSingleton<IEmailClient, MailKitEmailSender>();

        services
            .AddSerilogServices();

        services
            .Configure<SmtpOptions>(configuration.GetSection("Smtp"));

        return services;
    }
}