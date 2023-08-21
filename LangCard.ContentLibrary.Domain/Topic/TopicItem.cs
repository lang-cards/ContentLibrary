namespace LangCard.ContentLibrary.Domain.Topic;

public class TopicItem
{
    public int Id { get; set; }
    public required uint Order { get; set; }
    public required string Title { get; set; } = null!;
    public required TopicItemType Type { get; set; }
    public required string Data { get; set; } = null!;

}
