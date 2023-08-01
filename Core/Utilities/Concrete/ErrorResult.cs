namespace Core.Utilities.Concrete;

public class ErrorResult :Result
{
    public ErrorResult(bool isSuccess, string message) : base(false, message)
    {

    }

    public ErrorResult() : base(false)
    {

    }
}