using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangCard.ContentLibrary.Adapter.Postgress.Courses;

public class CourseEntityConfiguration : IEntityTypeConfiguration<CourseDal>
{
    public void Configure(EntityTypeBuilder<CourseDal> builder)
    {
        builder.ToTable("courses").HasKey(t => t.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.LanguageId);
        builder.Property(x => x.TranslateLanguageId);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.CreatedAt);

        builder.HasIndex(x => new { x.Name, x.LanguageId, x.TranslateLanguageId }).IsUnique(true);
    }
}

