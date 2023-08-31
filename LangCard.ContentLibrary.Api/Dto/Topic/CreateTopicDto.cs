namespace LangCard.ContentLibrary.Api.Dto.Topic;

public class CreateTopicDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int CourseId { get; set; }
    public int Order { get; set; }
}
