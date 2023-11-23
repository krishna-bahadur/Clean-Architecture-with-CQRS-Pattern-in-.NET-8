using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Presentation;

public static class AssemblyReferences
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
