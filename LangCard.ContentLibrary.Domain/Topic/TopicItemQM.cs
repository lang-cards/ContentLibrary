namespace LangCard.ContentLibrary.Domain.Topic;

public record TopicItemQM(
    int id,
    string title,
    string data,
    int topicId,
    uint order,
    TopicItemType topicItemType,
    DateTimeOffset createdAt,
    string createdBy);
