using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ICustomerService
{
    IResult Add(Customer customer);
    IResult Remove(Customer customer);
    IResult Update(Customer customer);
    IDataResult<List<Customer>> GetAll();
    IDataResult<Customer> GetById(int id);
}