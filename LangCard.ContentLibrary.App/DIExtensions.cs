using LangCard.ContentLibrary.App.Abstraction.Messaging.Pipelines;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangCard.ContentLibrary.App;

public static class DIExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DIExtensions).Assembly))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ErrorPipelineBehaviour<,>));


        return services;
    }
}
