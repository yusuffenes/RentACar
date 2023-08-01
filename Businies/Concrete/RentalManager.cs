using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
    IRentalDal _rentalDal;

    public RentalManager(IRentalDal rental)
    {
        _rentalDal = rental;
    }
    public IResult Add(Rental rental)
    {
        _rentalDal.Add(rental);
        return new SuccessResult(true,Messages.RentalAdded);
    }

    public IResult Remove(Rental rental)
    {
        _rentalDal.Delete(rental);
        return new SuccessResult(true, Messages.RentalDeleted);

    }

    public IResult Update(Rental rental)
    {
        _rentalDal.Update(rental);
        return new SuccessResult(true,Messages.RentalUpdated);
    }

    public IDataResult<List<Rental>> GetAll()
    {
        return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().ToList(),Messages.RentalListed);
    }

    public IDataResult<Rental> GetById(int id)
    {
        return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == id));
    }
}