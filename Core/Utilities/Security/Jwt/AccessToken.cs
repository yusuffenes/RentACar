namespace Core.Utilities.Security.Hashing;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}