using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Course;

namespace LangCard.ContentLibrary.App.Models.Courses.Commands;

public class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, int>
{
    private readonly ICourseRepository _сourseRepository;

    public CreateCourseCommandHandler(ICourseRepository сourseRepository)
    {
        _сourseRepository = сourseRepository;
    }

    public async Task<Result<int>> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
    {
        var course = Course.Create(command.name,
            command.description,
            command.languageId,
            command.translateLanguageId);
        var resultId = await _сourseRepository.Add(course, cancellationToken);
        return new Result<int>(resultId);
    }


}
