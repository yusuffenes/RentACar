using Core.Utilities.Abstract;

namespace Core.Utilities.Concrete;

public class Result : IResult
{
    public Result(bool isSuccess,string message) : this(isSuccess)
    {
        Message = message;
    }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }
    public string Message { get; }
}