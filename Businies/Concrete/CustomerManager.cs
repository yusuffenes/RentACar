using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{ 
    ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }
    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccessResult(true, Messages.CustomerAdded);


    }

    public IResult Remove(Customer customer)
    {
        _customerDal.Delete(customer);
        return new SuccessResult(true, Messages.CustomerDeleted);
    }

    public IResult Update(Customer customer)
    {
        _customerDal.Update(customer);
        return new SuccessResult(true,Messages.CustomerUpdated);
    }

    public IDataResult<List<Customer>> GetAll()
    {
        return new SuccessDataResult<List<Customer>>(_customerDal.GetAll().ToList(),Messages.CustomerListed);
    }

    public IDataResult<Customer> GetById(int id)
    {
        return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id), Messages.CustomerListed);
    }
}