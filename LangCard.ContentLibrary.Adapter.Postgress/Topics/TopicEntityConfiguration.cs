using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangCard.ContentLibrary.Adapter.Postgress.Topics;

public class TopicEntityConfiguration : IEntityTypeConfiguration<TopicDal>
{
    public void Configure(EntityTypeBuilder<TopicDal> builder)
    {
        builder.ToTable("topics").HasKey(t => t.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.Property(x => x.Order);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.CreatedAt);

        builder.HasOne(x => x.Course)
           .WithMany(x => x.Topics)
           .HasForeignKey(x => x.CourseId);

        builder.HasIndex(x => new { x.Name }).IsUnique(true);
    }
}
