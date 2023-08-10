using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IRentalService
{
    IResult Add(Rental rental);
    IResult Remove (Rental rental);
    IResult Update (Rental rental);
    IDataResult<List<Rental>> GetAll();
    IDataResult<List<RentalDetailDto>> GetRentalDetail();
    IDataResult<Rental> GetById (int id);

}