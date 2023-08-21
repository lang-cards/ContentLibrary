using LangCard.ContentLibrary.Adapter.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LangCard.ContentLibrary.Adapter.Postgress;

internal class DesignContextFactory : IDesignTimeDbContextFactory<ContentLibraryContext>
{
    public ContentLibraryContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<ContentLibraryContext>()
                .UseNpgsql("Host=localhost;Port=5432;Database=LangDictionary;UserName=postgres;Password=admin;Maximum Pool Size = 50", o => o.MigrationsAssembly(typeof(ContentLibraryContext).Assembly.GetName().Name))
                .Options;
        return new ContentLibraryContext(options);
    }
}
