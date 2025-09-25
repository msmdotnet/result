namespace Results;
public sealed class Result<TSuccess> : ResultBase
{
    public TSuccess Value { get; }
    
    private Result(TSuccess value) : base()
    {
        Value = value;
    }

    private Result(Error[] errors) : base(errors) { }
    private Result(string errorMessage) : base(errorMessage) { }

    public static Result<TSuccess> Ok(TSuccess value) => new(value);
    public static Result<TSuccess> Fail(params Error[] errors) => new(errors);
    public static Result<TSuccess> Fail(string errorMessage) => new(errorMessage);
}
