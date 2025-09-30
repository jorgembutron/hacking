using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HackingNews.App.Extensions;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Add application services here
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}