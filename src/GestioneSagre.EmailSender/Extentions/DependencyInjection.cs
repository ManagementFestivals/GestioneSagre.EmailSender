namespace GestioneSagre.EmailSender.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddEmailSenderService(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<ILoggerService, LoggerService>()
            .AddSingleton<IEmailSender, MailKitEmailSender>()
            .AddSingleton<IEmailClient, MailKitEmailSender>();

        services
            .Configure<SmtpOptions>(configuration.GetSection("Smtp"));

        return services;
    }
}