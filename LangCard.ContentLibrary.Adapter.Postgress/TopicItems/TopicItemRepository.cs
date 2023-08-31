using LangCard.ContentLibrary.Adapter.Postgres;
using LangCard.ContentLibrary.Adapter.Postgress.TopicItems;
using LangCard.ContentLibrary.Domain.Topic;

namespace LangCard.ContentLibrary.Adapter.Postgress.TopicItems;

public class TopicItemRepository : ITopicItemRepository
{
    private readonly ContentLibraryContext _db;

    public TopicItemRepository(ContentLibraryContext db)
    {
        _db = db;
    }

    public async Task<int> Add(TopicItem topicItem, CancellationToken cancellationToken)
    {
        var topicItemDal = new TopicItemDal
        {
            Title = topicItem.Title,
            Data = topicItem.Data,
            TopicId = topicItem.TopicId,
            Order = topicItem.Order,
            TopicItemType = topicItem.TopicItemType,
            CreatedAt = topicItem.CreatedAt,
            CreatedBy = topicItem.CreatedBy
        };
        await _db.TopicItems.AddAsync(topicItemDal);
        await _db.SaveChangesAsync(cancellationToken);
        return topicItemDal.Id;
    }

    public Task Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(TopicItem topic, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    Task<TopicItem?> ITopicItemRepository.GetById(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
