namespace Results.Extensions;
public static class ResultExtensions
{
    public static TResult Match<TResult>(
        this Result result,
        Func<TResult> onSuccess,
        Func<Result, TResult> onError)
    {
        return result.IsSuccess
            ? onSuccess()
            : onError(result);
    }

    public static void Match(
        this Result result,
        Action onSuccess,
        Action<Result> onError)
    {
        if (result.IsSuccess)
            onSuccess();
        else
            onError(result);
    }
}

