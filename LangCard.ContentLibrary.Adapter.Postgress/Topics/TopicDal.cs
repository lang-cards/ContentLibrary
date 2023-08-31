using LangCard.ContentLibrary.Adapter.Postgress.Courses;
using LangCard.ContentLibrary.Adapter.Postgress.TopicItems;

namespace LangCard.ContentLibrary.Adapter.Postgress.Topics;

public class TopicDal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public int CourseId { get; set; }
    public CourseDal Course { get; set; }
    public ICollection<TopicItemDal>? TopicItems { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; }
}
