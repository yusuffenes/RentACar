using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface ICarDal : IEntityRepository<Car>
{
    List<CarDetailDto> GetCarDetails();
    List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId);
    List<CarDetailDto> GetCarDetailByCarId(int carId);
    List<CarDetailDto> GetCarDetailByBrandId(int brandId);
    List<CarDetailDto> GetCarDetailByColorId(int colorId);
}