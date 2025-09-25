namespace Results.Extensions;
public static class ResultTSuccessErrorExtensions
{
    public static TResult Match<TSuccess, TError, TResult>(
        this Result<TSuccess, TError> result,
        Func<TSuccess, TResult> onSuccess,
        Func<TError, TResult> onError)
    {
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onError(result.Error);
    }

    public static void Match<TSuccess, TError>(
        this Result<TSuccess, TError> result,
        Action<TSuccess> onSuccess,
        Action<TError> onError)
    {
        if (result.IsSuccess)
            onSuccess(result.Value);
        else
            onError(result.Error);
    }
}

