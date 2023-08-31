using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.App.Models.Topics.Queries;

public record GetTopicQMQuery(int id) : IQuery<TopicQM>;