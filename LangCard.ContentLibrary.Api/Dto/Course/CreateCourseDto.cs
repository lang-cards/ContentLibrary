namespace LangCard.ContentLibrary.Api.Dto.Course;

public class CreateCourseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int LanguageId { get; set; }
    public int TranslateLanguageId { get; set; }
}
