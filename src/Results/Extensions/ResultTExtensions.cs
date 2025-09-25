namespace Results.Extensions;
public static class ResultTExtensions
{
    public static TResult Match<T, TResult>(
        this Result<T> result,
        Func<T, TResult> onSuccess,
        Func<Result<T>, TResult> onError)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onError(result);
    }

    public static void Match<T>(
        this Result<T> result,
        Action<T> onSuccess,
        Action<Result<T>> onError)
    {
        if (result.IsSuccess)
            onSuccess(result.Value);
        else
            onError(result);
    }
}

