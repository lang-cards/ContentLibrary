using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.App.Models.Topics.Queries;
using LangCard.ContentLibrary.Domain.Common.Extensions;
using LangCard.ContentLibrary.Domain.Course;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.Courses.Queries;

public class GetTopicQMQueryHandler : IQueryHandler<GetTopicQMQuery, TopicQM>
{
    private readonly ITopicRepository _topicRepository;

    public GetTopicQMQueryHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }

    public async Task<Result<TopicQM>> Handle(GetTopicQMQuery request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetById(request.id, cancellationToken);
        if (topic is null)
            return Result<TopicQM>.CreateError($"TopicQM not found by id {request.id}");

        var topicQM = topic.MapNotNull(topic => ToTopicQM(topic));
        return new Result<TopicQM>(topicQM);
    }

    private TopicQM ToTopicQM(Topic topic)
    {
        return new TopicQM(
            topic.Id,
            topic.Name,
            topic.Description,
            topic.Order,
            topic.TopicItems,
            topic.CreatedAt,
            topic.CreatedBy);
    }
}
