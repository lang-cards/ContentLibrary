using LangCard.ContentLibrary.App.Abstraction.Messaging;
using LangCard.ContentLibrary.Domain.Course;

namespace LangCard.ContentLibrary.App.Models.Courses.Queries;

public record GetCourseQMQuery(int id) : IQuery<CourseQM>;