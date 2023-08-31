using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.Api.Dto.TopicItem;

public class CreateTopicItemDto
{
    public required string Title { get; set; }
    public required string Data { get; set; }
    public int TopicId { get; set; }
    public TopicItemType TopicItemType { get; set; }
    public uint Order { get; set; }
}
