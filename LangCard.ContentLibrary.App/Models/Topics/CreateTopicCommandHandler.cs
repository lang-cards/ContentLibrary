using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.App.Models.Courses.Commands;
using LangCard.ContentLibrary.Domain.Course;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.Topics;

public class CreateTopicCommandHandler : ICommandHandler<CreateTopicCommand, int>
{
    private readonly ITopicRepository _topicRepository;
    private readonly ICourseRepository _сourseRepository;

    public CreateTopicCommandHandler(ITopicRepository topicRepository, ICourseRepository сourseRepository)
    {
        _topicRepository = topicRepository;
        _сourseRepository = сourseRepository;
    }

    public async Task<Result<int>> Handle(CreateTopicCommand command, CancellationToken cancellationToken)
    {
        var course = await _сourseRepository.GetById(command.courseId, cancellationToken);
        if(course == null)
            return (Result<int>)Result.CreateError("Course not found");

        var topic = Topic.Create(command.name,
            command.description,
            command.courseId,
            command.order);
        var resultId = await _topicRepository.Add(topic, cancellationToken);
        return new Result<int>(resultId);
    }


}
