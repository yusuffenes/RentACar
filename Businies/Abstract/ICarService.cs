using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Color = System.Drawing.Color;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult<List<Car>> GetAll();
    IDataResult<List<CarDetailDto>> GetCarDetail();
    IResult Add(Car car);
    IResult Remove(Car car);
    IResult Update(Car car);

    IResult AddTransactionalTest(Car car);
    IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId);
    IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId);
    IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
    IDataResult<List<CarDetailDto>> GetCarDetailByColorAndBrandId(int brandId, int colorId);
}