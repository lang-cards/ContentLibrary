using LangCard.ContentLibrary.Adapter.Postgress.Courses;
using LangCard.ContentLibrary.Adapter.Postgress.Topics;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.Adapter.Postgress.TopicItems;

public class TopicItemDal
{
    public int Id { get; set; }
    public required int TopicId { get; set; }
    public TopicDal Topic { get; set; }
    public required uint Order { get; set; }
    public required string Title { get; set; } = null!;
    public required TopicItemType TopicItemType { get; set; }
    public required string Data { get; set; } = null!;
    public required DateTimeOffset CreatedAt { get; set; }
    public required string CreatedBy { get; set; }
}
