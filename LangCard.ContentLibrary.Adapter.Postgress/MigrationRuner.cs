using LangCard.ContentLibrary.Adapter.Postgres;
using Microsoft.EntityFrameworkCore;

namespace LangCard.ContentLibrary.Adapter.Postgress;

internal class MigrationRuner
{
    private ContentLibraryContext _context;

    public MigrationRuner(ContentLibraryContext context)
    {
        _context = context;
    }

    public async Task Run()
    {
        var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            await _context.Database.MigrateAsync();
        }
    }
}
