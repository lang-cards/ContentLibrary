using LangCard.ContentLibrary.Adapter.Postgres;
using LangCard.ContentLibrary.Domain.Common.Extensions;
using LangCard.ContentLibrary.Domain.Course;
using LangCard.ContentLibrary.Domain.Topic;
using Microsoft.EntityFrameworkCore;

namespace LangCard.ContentLibrary.Adapter.Postgress.Courses;

public class CourseRepository : ICourseRepository
{
    private readonly ContentLibraryContext _db;

    public CourseRepository(ContentLibraryContext db)
    {
        _db = db;
    }

    public async Task<int> Add(Course course, CancellationToken cancellationToken)
    {
        var courseDal = new CourseDal
        {
            Name = course.Name,
            Description = course.Description,
            LanguageId = course.LanguageId,
            TranslateLanguageId = course.TranslateLanguageId,
            CreatedAt = course.CreatedAt,
            CreatedBy = course.CreatedBy
        };
        await _db.Courses.AddAsync(courseDal);
        await _db.SaveChangesAsync(cancellationToken);
        return courseDal.Id;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Course[]> Get(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Course?> GetById(int id, CancellationToken cancellationToken)
    {
        var courseDal = await _db.Courses
             .Include(x => x.Topics)
             .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return courseDal.MapNotNull(dal => Course.RestoreState(
            dal.Id,
            dal.Name,
            dal.Description,
            dal.LanguageId,
            dal.TranslateLanguageId,
            dal.Topics!
                .Select(topic => new TopicQM(topic.Id, topic.Name, topic.Description, topic.Order, topic.CreatedAt, topic.CreatedBy))
                .ToArray(),
            dal.CreatedAt,
            dal.CreatedBy));

    }

    public Task Update(Course course, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
