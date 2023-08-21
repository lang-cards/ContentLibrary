using LangCard.ContentLibrary.Adapter.Postgress.Topics;

namespace LangCard.ContentLibrary.Adapter.Postgress.Courses;

public class CourseDal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public int TranslateLanguageId { get; set; }
    public ICollection<TopicDal>? Topics { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}
