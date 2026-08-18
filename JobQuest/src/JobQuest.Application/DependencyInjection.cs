using Microsoft.Extensions.DependencyInjection;

namespace JobQuest.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here (e.g., MediatR handlers, AutoMapper, etc.)
        return services;
    }
}
