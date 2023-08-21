using LangCard.ContentLibrary.App.Models;          
using MediatR;
using Microsoft.Extensions.Logging;

namespace LangCard.ContentLibrary.App.Abstraction.Messaging.Pipelines;

public class ErrorPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<ErrorPipelineBehaviour<TRequest, TResponse>> _logger;

    public ErrorPipelineBehaviour(ILogger<ErrorPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next();
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Unhandled error was catch for {TRequest}", typeof(TRequest).Name);
            return ToErrorResponse(e);
        }
    }

    private TResponse ToErrorResponse(Exception e)
    {
        var responseType = typeof(TResponse);
        if (responseType == typeof(Result))
        {
            return (TResponse)(dynamic)Result.CreateError(e.Message);
        }

        var typedResultType = typeof(Result<>);
        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typedResultType)
        {
            dynamic errorResponse = responseType
                .GetMethod(nameof(Result<TResponse>.CreateError))
                .Invoke(null, new object[] { e.Message });

            return (TResponse)errorResponse;
        }

        return default(TResponse);
    }
}
