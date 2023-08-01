using Core.Entities.Concrete;

namespace Core.Utilities.Security.Hashing;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}