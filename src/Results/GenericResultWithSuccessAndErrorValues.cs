namespace Results;
public sealed class Result<TSuccess, TError>
{
    private readonly TSuccess ValueField;
    private readonly TError ErrorField;

    public TSuccess Value => IsSuccess
        ? ValueField
        : throw new InvalidOperationException(
            Messages.CannotAccessValueWhenResultIsFailureMessage);
    public TError Error => IsFailure
        ? ErrorField
        : throw new InvalidOperationException(
            Messages.CannotAccessErrorWhenResultIsSuccess);

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    private Result(TSuccess value)
    {
        IsSuccess = true;
        ValueField = value;
    }

    private Result(TError value)
    {
        IsSuccess = false;
        ErrorField = value;
    }

    public static Result<TSuccess, TError> Ok(TSuccess successValue) => new(successValue);
    public static Result<TSuccess, TError> Fail(TError errorValue) => new(errorValue);
}
