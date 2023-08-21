using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.Topics;

public class UpdateTopicCommandHandler : ICommandHandler<UpdateTopicCommand>
{
    private readonly ITopicRepository _topicRepository;

    public UpdateTopicCommandHandler(ITopicRepository topicRepository)
    {
        _topicRepository = topicRepository;
    }
    public async Task<Result> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await _topicRepository.GetById(request.id, cancellationToken);
        if (topic == null)
            return Result.CreateError($"Topic with Id: {request.id} not found");

        topic.Edit(request.name, request.description, request.order);
        await _topicRepository.Update(topic, cancellationToken);
        return Result.CreateSuccess();
    }
}
