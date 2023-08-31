using LangCard.ContentLibrary.Adapter.Postgress.Courses;
using LangCard.ContentLibrary.Adapter.Postgress.TopicItems;
using LangCard.ContentLibrary.Adapter.Postgress.Topics;
using Microsoft.EntityFrameworkCore;

namespace LangCard.ContentLibrary.Adapter.Postgres;

public class ContentLibraryContext : DbContext
{
    public DbSet<CourseDal> Courses { get; set; }
    public DbSet<TopicDal> Topics { get; set; }
    public DbSet<TopicItemDal> TopicItems { get; set; }

    public ContentLibraryContext(DbContextOptions<ContentLibraryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContentLibraryContext).Assembly);
    }
}
