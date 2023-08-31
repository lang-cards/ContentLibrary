using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.TopicItems.Commands;

public class CreateTopicItemCommandHandler : ICommandHandler<CreateTopicItemCommand, int>
{
    private readonly ITopicRepository _topicRepository;
    private readonly ITopicItemRepository _topicItemRepository;

    public CreateTopicItemCommandHandler(ITopicRepository topicRepository, ITopicItemRepository topicItemRepository)
    {
        _topicRepository = topicRepository;
        _topicItemRepository = topicItemRepository;
    }

    public async Task<Result<int>> Handle(CreateTopicItemCommand command, CancellationToken cancellationToken)
    {
        var course = await _topicRepository.GetById(command.topicId, cancellationToken);
        if (course == null)
            return (Result<int>)Result.CreateError("Topic not found");

        var topicItem = TopicItem.Create(command.tittle,
            command.data,
            command.topicId,
            command.topicItemType,
            command.order);
        var resultId = await _topicItemRepository.Add(topicItem, cancellationToken);
        return new Result<int>(resultId);
    }


}
