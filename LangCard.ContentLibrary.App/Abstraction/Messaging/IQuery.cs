using LangCard.ContentLibrary.App.Models;
using MediatR;

namespace LangCard.ContentLibrary.App.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
