using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationAuthorization.Application;
public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}
