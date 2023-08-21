namespace LangCard.ContentLibrary.Api.Dto.Topic;

public class CreateTopicDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CourseId { get; set; }
    public int Order { get; set; }
}
