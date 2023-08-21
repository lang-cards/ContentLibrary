using LangCard.ContentLibrary.App.Models;
using MediatR;

namespace LangCard.ContentLibrary.App.Abstraction.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
