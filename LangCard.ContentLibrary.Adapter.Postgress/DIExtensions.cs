using LangCard.ContentLibrary.Adapter.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LangCard.ContentLibrary.Adapter.Postgress;

public static class DIExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DbContext, ContentLibraryContext>(ob => ob.UseNpgsql(connectionString, o => o.MigrationsAssembly(typeof(ContentLibraryContext).Assembly.GetName().Name)), ServiceLifetime.Scoped);
        services.AddScoped<MigrationRuner>();

        services.Scan(selector => selector
            .FromAssemblyOf<ContentLibraryContext>()
            .AddClasses(publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }

    public static async Task RunMigrations(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var runner = scope.ServiceProvider.GetRequiredService<MigrationRuner>();
        await runner.Run();
    }
}
