using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.TopicItems.Commands;

public record CreateTopicItemCommand(
    string tittle,
    string data,
    int topicId,
    TopicItemType topicItemType,
    uint order) : ICommand<int>;
