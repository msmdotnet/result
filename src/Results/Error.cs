namespace Results;
public class Error(string code, string message)
{
    public string Code => code;
    public string Message => message;

    public Error(string message) : this(null, message) 
    { }
}
