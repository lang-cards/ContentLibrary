using LangCard.ContentLibrary.Adapter.Postgres;
using LangCard.ContentLibrary.Domain.Common.Extensions;
using LangCard.ContentLibrary.Domain.Topic;
using Microsoft.EntityFrameworkCore;

namespace LangCard.ContentLibrary.Adapter.Postgress.Topics;

public class TopicRepository : ITopicRepository
{
    private readonly ContentLibraryContext _db;

    public TopicRepository(ContentLibraryContext db)
    {
        _db = db;
    }

    public async Task<int> Add(Topic topic, CancellationToken cancellationToken)
    {
        var topicDal = new TopicDal
        {
            Name = topic.Name,
            Description = topic.Description,
            CourseId = topic.CourseId,
            Order = topic.Order,
            CreatedAt = topic.CreatedAt,
            CreatedBy = topic.CreatedBy
        };
        await _db.Topics.AddAsync(topicDal);
        await _db.SaveChangesAsync(cancellationToken);
        return topicDal.Id;
    }

    public Task Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Topic?> GetById(int id, CancellationToken cancellationToken)
    {
        var topicDal = await _db.Topics
            .Include(x => x.TopicItems)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return topicDal.MapNotNull(dal => Topic.RestoreState(
            dal.Id,
            dal.Name,
            dal.Description,
            dal.CourseId,
            dal.Order,
            dal.TopicItems!
                .Select(ti => new TopicItemQM(ti.Id, ti.Title, ti.Data, ti.TopicId, ti.Order, ti.TopicItemType, ti.CreatedAt, ti.CreatedBy))
                .ToArray(),            
            dal.CreatedAt,
            dal.CreatedBy));
    }

    public async Task Update(Topic topic, CancellationToken cancellationToken)
    {
        var topicDal = _db.Topics.FirstOrDefault(x => x.Id == topic.Id);

        topicDal.Name = topic.Name;
        topicDal.Description = topic.Description;
        topicDal.Order = topic.Order;
        await _db.SaveChangesAsync(cancellationToken);
    }
}
