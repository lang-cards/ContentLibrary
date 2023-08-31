using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Common.Extensions;
using LangCard.ContentLibrary.Domain.Course;

namespace LangCard.ContentLibrary.App.Models.Courses.Queries;

public class GetCourseQMQueryHandler : IQueryHandler<GetCourseQMQuery, CourseQM>
{
    private readonly ICourseRepository _сourseRepository;

    public GetCourseQMQueryHandler(ICourseRepository сourseRepository)
    {
        _сourseRepository = сourseRepository;
    }

    public async Task<Result<CourseQM>> Handle(GetCourseQMQuery request, CancellationToken cancellationToken)
    {
        var course = await _сourseRepository.GetById(request.id, cancellationToken);
        if (course is null)
            return Result<CourseQM>.CreateError($"CourseQM not found by id {request.id}");

        var courseQM = course.MapNotNull(course => ToCourseQM(course));
        return new Result<CourseQM>(courseQM);
    }

    private CourseQM ToCourseQM(Course course)
    {
        return new CourseQM(
            course.Id,
            course.Name,
            course.Description,
            course.LanguageId,
            course.TranslateLanguageId,
            course.Topics,
            course.CreatedAt,
            course.CreatedBy);
    }
}
