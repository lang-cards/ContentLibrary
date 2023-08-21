using LangCard.ContentLibrary.App.Models;
using MediatR;

namespace LangCard.ContentLibrary.App.Abstraction.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
