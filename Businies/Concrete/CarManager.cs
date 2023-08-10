 using Business.Abstract;
 using Business.BusinessAspect.Autofac;
 using Business.Constants;
 using Business.ValidationRules.FluentValidation;
 using Core.Aspects.Autofac.Caching;
 using Core.Aspects.Autofac.Validation;
 using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
 using Microsoft.EntityFrameworkCore.Infrastructure;
 using Color = System.Drawing.Color;

namespace Business.Concrete;

public class CarManager : ICarService
{
    ICarDal _carDal;

    public CarManager(ICarDal carDal)
    {
        _carDal = carDal;
    }
    
    public IDataResult<List<Car>> GetAll()
    {
        if (System.DateTime.Now.Hour == 20)
        {
            return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
        }
        else
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }
    }
    [CacheAspect]
    public IDataResult<List<CarDetailDto>> GetCarDetail()
    {
        return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarListed);
       
    }
    [ValidationAspect(typeof(CarValidator))]
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Add(Car car)
    {
        if (car.Description.Length > 2 || car.DailyPrice > 0)
        {
            _carDal.Add(car);
            return new SuccessResult(true,Messages.CarAdded);
            
        }
        else
        {
            return new ErrorResult(false,Messages.CarNameInvalid);
            
        }
        
    }

    public IResult Remove(Car car)
    {
        _carDal.Delete(car);
        return  new SuccessResult();
    }
    [CacheRemoveAspect("ICarService.Get")]
    public IResult Update(Car car)
    {
        _carDal.Update(car);
        return new SuccessResult(true,Messages.RentalUpdated);
    }

    public IResult AddTransactionalTest(Car car)
    {
        Add(car);
        if (car.DailyPrice <15)
        {
            throw new Exception("");
        }

        Add(car);
        return null;
    }
}