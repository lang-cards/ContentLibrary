using LangCard.ContentLibrary.Api.Dto.TopicItem;
using LangCard.ContentLibrary.App.Models.Courses.Queries;
using LangCard.ContentLibrary.App.Models.TopicItems.Commands;
using LangCard.ContentLibrary.App.Models.Topics.Queries;
using LangCard.ContentLibrary.Domain.Course;
using LangCard.ContentLibrary.Domain.Topic;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LangCard.ContentLibrary.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicItemsController : ControllerBase
{
    private readonly ISender _sender;

    public TopicItemsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<TopicQM> Get(int id)
    {
        var result = await _sender.Send(
            new GetTopicQMQuery(id));

        return result.Value;
    }

    [HttpPost]
    public async Task<int> Post([FromBody] CreateTopicItemDto model)
    {
        var result = await _sender.Send(
            new CreateTopicItemCommand(
                model.Title,
                model.Data,
                model.TopicId,
                model.TopicItemType,
                model.Order));

        return result.Value;
    }
}
