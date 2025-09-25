namespace Results;
public class ResultBase
{
    public Error[] Errors { get; }
    public Error Error => Errors.Length > 0 ? Errors[0] : null;
    public string ErrorMessage => Error?.Message;
    public bool IsFailure => Errors.Length > 0;
    public bool IsSuccess => !IsFailure;

    protected ResultBase() => Errors = [];
    protected ResultBase(Error[] errors)
    {
        Errors = errors ?? throw new ArgumentNullException(nameof(errors));
    }
    protected ResultBase(string errorMessage) : this([new Error(errorMessage)])
    { }
}
