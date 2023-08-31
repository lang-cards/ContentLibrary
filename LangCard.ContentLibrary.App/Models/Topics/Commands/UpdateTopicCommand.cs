using LangCard.ContentLibrary.App.Abstraction.Messaging;

namespace LangCard.ContentLibrary.App.Models.Topics.Commands;

public record UpdateTopicCommand(
    int id,
    string name,
    string description,
    int order) : ICommand;
