using LangCard.ContentLibrary.App.Abstraction.Messaging;

namespace LangCard.ContentLibrary.App.Models.Courses.Commands;

public record CreateCourseCommand(
    string name,
    string description,
    int languageId,
    int translateLanguageId) : ICommand<int>;

