using LangCard.ContentLibrary.Api.Dto.Topic;
using LangCard.ContentLibrary.App.Models;
using LangCard.ContentLibrary.App.Models.Topics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangCard.ContentLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController : ControllerBase
{
    private readonly ISender _sender;

    public TopicsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<int> Post([FromBody] CreateTopicDto model)
    {
        var result = await _sender.Send(
            new CreateTopicCommand(
                model.Name,
                model.Description,
                model.CourseId,
                model.Order));

        return result.Value;
    }

    [HttpPut]
    public async Task<Result> Put(int id, [FromBody] UpdateTopicDto model)
    {
        var result = await _sender.Send(
            new UpdateTopicCommand(
                id,
                model.Name,
                model.Description,
                model.Order));

        return result;
    }
}
