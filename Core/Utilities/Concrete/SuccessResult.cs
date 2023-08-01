namespace Core.Utilities.Concrete;

public class SuccessResult : Result
{
    public SuccessResult(bool isSuccess, string message) : base(true,message)
    {
        
    }

    public SuccessResult() : base(true)
    {

    }
}