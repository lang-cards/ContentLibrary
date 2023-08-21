using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.Domain.Course;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public int TranslateLanguageId { get; set; }
    public TopicQM[] Topics { get; set; } = Array.Empty<TopicQM>();
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }

    public static Course Create(
        string name,
        string description,
        int languageId,
        int translateLanguageId)
    {
        return new Course
        {
            Name = name,
            Description = description,
            LanguageId = languageId,
            TranslateLanguageId = translateLanguageId,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "default@user"
        };
    }

    public static Course RestoreState(
        int id,
        string name,
        string description,
        int languageId,
        int translateLanguageId,
        TopicQM[] topics,
        DateTimeOffset createdAt,
        string createdBy)
    {
        return new Course
        {
            Id = id,
            Name = name,
            Description = description,
            LanguageId = languageId,
            TranslateLanguageId = translateLanguageId,
            Topics = topics,
            CreatedAt = createdAt,
            CreatedBy = createdBy
        };
    }
}


