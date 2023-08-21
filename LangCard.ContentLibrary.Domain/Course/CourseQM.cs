using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.Domain.Course;

public record class CourseQM(
    int id,
    string name,
    string description,
    int languageId,
    int translateLanguageId,
    TopicQM[] topics,
    DateTimeOffset createdAt,
    string createdBy);
