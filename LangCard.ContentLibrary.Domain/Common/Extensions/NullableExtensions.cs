namespace LangCard.ContentLibrary.Domain.Common.Extensions;

public static class NullableExtensions
{
    public static TResult? MapNotNull<TValue, TResult>(this TValue? target, Func<TValue, TResult> map)
        where TValue : class
    {
        return target is null ? default : map(target);
    }

    public static TResult? MapNotNull<TValue, TResult>(this Nullable<TValue> target, Func<TValue, TResult> map)
        where TValue : struct
    {
        return !target.HasValue ? default : map(target.Value);
    }
}
