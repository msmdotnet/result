namespace Results;
public sealed class Result : ResultBase
{
    private Result(): base(){}
    private Result(Error[] errors) : base(errors) { }
    private Result(string errorMessage) : base(errorMessage) {}

    public static Result Ok() => new();
    public static Result Fail(params Error[] errors) => new(errors);
    public static Result Fail(string errorMessage) => new(errorMessage);
}
