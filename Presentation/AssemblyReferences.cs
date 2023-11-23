using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Presentation.EndPoints.Items;

namespace Presentation;

public static class AssemblyReferences
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");
        return services;
    }
    
    public static IEndpointRouteBuilder AddEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapItemEndPoints();
        return app;
    }
}
