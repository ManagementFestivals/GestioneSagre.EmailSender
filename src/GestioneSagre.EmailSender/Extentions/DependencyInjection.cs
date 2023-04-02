namespace GestioneSagre.EmailSender.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddMailKitEmailSenderService(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton<IEmailSender, MailKitEmailSender>()
            .AddSingleton<IEmailClient, MailKitEmailSender>();

        services
            .Configure<SmtpOptions>(configuration.GetSection("Smtp"));

        return services;
    }
}