namespace LangCard.ContentLibrary.Domain.Topic;

public interface ITopicItemRepository
{
    public Task<TopicItem?> GetById(int id, CancellationToken cancellationToken);
    public Task<int> Add(TopicItem topic, CancellationToken cancellationToken);
    public Task Update(TopicItem topic, CancellationToken cancellationToken);
    public Task Delete(int id, CancellationToken cancellationToken);
}
