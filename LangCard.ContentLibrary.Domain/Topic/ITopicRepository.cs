namespace LangCard.ContentLibrary.Domain.Topic;

public interface ITopicRepository
{
    public Task<Topic?> GetById(int id, CancellationToken cancellationToken);
    public Task<int> Add(Topic topic, CancellationToken cancellationToken);
    public Task Update(Topic topic, CancellationToken cancellationToken);
    public Task Delete(int id, CancellationToken cancellationToken);
}
