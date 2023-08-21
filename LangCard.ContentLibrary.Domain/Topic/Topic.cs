namespace LangCard.ContentLibrary.Domain.Topic;
public class Topic
{
    public int Id { get; set; }
    public int CourseId { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }

    public List<TopicItem> TopicItems { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public static Topic Create(
    string name,
    string description,
    int courseId,
    int order)
    {
        return new Topic
        {
            Name = name,
            Description = description,
            CourseId = courseId,
            Order = order,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "default@user"
        };
    }

    public void Edit(
        string name,
        string description,
        int order)
    {
        Name = name;
        Description = description;
        Order = order;
    }

    public static Topic RestoreState(
    int id,
    string name,
    string description,
    int courseId,
    int order,
    DateTimeOffset createdAt,
    string createdBy)
    {
        return new Topic
        {
            Id = id,
            Name = name,
            Description = description,
            CourseId = courseId,
            Order = order,
            CreatedAt = createdAt,
            CreatedBy = createdBy
        };
    }
}

