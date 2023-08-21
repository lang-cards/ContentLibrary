namespace LangCard.ContentLibrary.App.Models;

public class Result<T> : Result
{
    public Result(T value)
        : base(isSuccess: true)
    {
        Value = value;
    }

    private Result(string error)
        : base(isSuccess: false, error)
    {
    }

    public T Value { get; private set; }

    public static new Result<T> CreateError(string? error) => new Result<T>(error);
}

public class Result
{
    protected Result(bool isSuccess, string? error = null)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; private set; }

    public string? Error { get; private set; }

    public static Result CreateError(string error) => new Result(isSuccess: false, error);

    public static Result CreateSuccess() => new Result(isSuccess: true);
}
