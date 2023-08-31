using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LangCard.ContentLibrary.Adapter.Postgress.TopicItems;

public class TopicItemEntityConfiguration : IEntityTypeConfiguration<TopicItemDal>
{
    public void Configure(EntityTypeBuilder<TopicItemDal> builder)
    {
        builder.ToTable("topics_item").HasKey(t => t.Id);

        builder.Property(x => x.Title);
        builder.Property(x => x.Data);
        builder.Property(x => x.Order);
        builder.Property(x => x.TopicItemType);
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.CreatedAt);
        
        builder.HasOne(x => x.Topic)
           .WithMany(x => x.TopicItems)
           .HasForeignKey(x => x.TopicId);
    }
}
