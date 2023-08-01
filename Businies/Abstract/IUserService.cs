using Core.Entities.Concrete;
using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IUserService
{
    IDataResult<List<User>> GetAll();
    IResult Add(User user);
    IResult Delete(User user);
    IResult Update(User user);
    IDataResult<User> GetById(int userId);
    IDataResult<User> GetByMail(string email);
    IDataResult<List<OperationClaim>> GetClaims(User user);
}