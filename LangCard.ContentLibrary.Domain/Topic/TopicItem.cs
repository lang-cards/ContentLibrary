namespace LangCard.ContentLibrary.Domain.Topic;

public class TopicItem
{
    public int Id { get; set; }
    public required int TopicId { get; set; }
    public required uint Order { get; set; }
    public required string Title { get; set; } = null!;
    public required TopicItemType TopicItemType { get; set; }
    public required string Data { get; set; } = null!;
    public required DateTimeOffset CreatedAt { get; set; }
    public required string CreatedBy { get; set; }

    public static TopicItem Create(
        string title,
        string data,
        int topicId,
        TopicItemType topicItemType,
        uint order)
    {
        return new TopicItem
        {
            Title = title,
            Data = data,
            TopicId = topicId,
            Order = order,
            TopicItemType = topicItemType,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "default@user"
        };
    }

    public void Edit(
        string title,
        string data,
        uint order)
    {
        Title = title;
        Data = data;
        Order = order;
    }

    public static TopicItem RestoreState(
    int id,
    string title,
    string data,
    int topicId,
    TopicItemType topicItemType,
    uint order,
    DateTimeOffset createdAt,
    string createdBy)
    {
        return new TopicItem
        {
            Id = id,
            Title = title,
            Data = data,
            TopicId = topicId,
            Order = order,
            TopicItemType = topicItemType,
            CreatedAt = createdAt,
            CreatedBy = createdBy
        };
    }

}
