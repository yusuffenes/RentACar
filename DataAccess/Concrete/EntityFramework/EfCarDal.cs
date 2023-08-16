using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal :EfEntityRepositoryBase<Car,CarContext>, ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (CarContext context = new CarContext())
        {
            var result = from car in context.Cars
                join b in context.Brands
                    on car.BrandId equals b.Id
                join c in context.Colors
                    on car.ColorId equals c.Id
                select new CarDetailDto
                {
                    Id = car.Id,
                    BrandId = b.Id,
                    ColorId = c.Id,
                    BrandName = b.Name,
                    ColorName = c.Name,
                    DailyPrice = car.DailyPrice,
                    Description = car.Description,
                    ModelYear = car.ModelYear,
                    ImageFolder = (from ci in context.CarImages where ci.CarId == car.Id select ci.ImageFolder).FirstOrDefault()
                };
                
            return result.ToList();
        }
    }

    

    public List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId)
    {
        using (CarContext context = new CarContext())
        {
            var result = from car in context.Cars
                join b in context.Brands
                    on car.BrandId equals b.Id
                join c in context.Colors
                    on car.ColorId equals c.Id
                where c.Id == colorId && b.Id ==brandId
                select new CarDetailDto
                {
                    Id = car.Id,
                    BrandName = b.Name,
                    ColorName = c.Name,
                    BrandId = b.Id,
                    ColorId = c.Id,
                    Description = car.Description,
                    DailyPrice = car.DailyPrice,
                    ModelYear = car.ModelYear,
                    ImageFolder = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImageFolder).FirstOrDefault()
                };
            return result.ToList();
        }
    }
    public List<CarDetailDto> GetCarDetailByBrandId(int brandId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where b.Id == brandId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImageFolder = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImageFolder).FirstOrDefault() 
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByCarId(int carId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join c in context.Colors
                             on car.ColorId equals c.Id
                             where car.Id == carId
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 BrandId = b.Id,
                                 ColorId = c.Id,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 ImageFolder = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImageFolder).FirstOrDefault()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailByColorId(int colorId)
        {
            using (CarContext context = new CarContext())
            {
                var result = from car in context.Cars
                    join b in context.Brands
                        on car.BrandId equals b.Id
                    join c in context.Colors
                        on car.ColorId equals c.Id
                    where c.Id == colorId
                    select new CarDetailDto
                    {
                        Id = car.Id,
                        BrandId = b.Id,
                        ColorId = c.Id,
                        BrandName = b.Name,
                        ColorName = c.Name,
                        Description = car.Description,
                        DailyPrice = car.DailyPrice,
                        ModelYear = car.ModelYear,
                        ImageFolder = (from ci in context.CarImages where car.Id == ci.CarId select ci.ImageFolder).FirstOrDefault()
                    };
                return result.ToList();
            }
        }
}

