using LangCard.ContentLibrary.Api.Dto.Course;
using LangCard.ContentLibrary.App.Models.Courses.Commands;
using LangCard.ContentLibrary.App.Models.Courses.Queries;
using LangCard.ContentLibrary.Domain.Course;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LangCard.ContentLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ISender _sender;

    public CoursesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<CourseQM> Get(int id)
    {
        var result = await _sender.Send(
            new GetCourseQMQuery(id));

        return result.Value;
    }

    [HttpPost]
    public async Task<int> Post([FromBody] CreateCourseDto model)
    {
        var result = await _sender.Send(
            new CreateCourseCommand(
                model.Name,
                model.Description,
                model.LanguageId,
                model.TranslateLanguageId));

        return result.Value;
    }
}
