namespace LangCard.ContentLibrary.Domain.Topic;

public record TopicQM(
    int id,
    string name,
    string description,
    int order,
    TopicItemQM[] topicItems,
    DateTimeOffset createdAt,
    string createdBy);
