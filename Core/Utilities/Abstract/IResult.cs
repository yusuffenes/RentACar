namespace Core.Utilities.Abstract;

public interface IResult
{
    public bool IsSuccess { get; }
    public string Message { get; }
}