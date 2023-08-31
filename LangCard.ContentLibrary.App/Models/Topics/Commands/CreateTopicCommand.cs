using LangCard.ContentLibrary.App.Abstraction.Messaging;

namespace LangCard.ContentLibrary.App.Models.Topics.Commands;

public record CreateTopicCommand(
    string name,
    string description,
    int courseId,
    int order) : ICommand<int>;
