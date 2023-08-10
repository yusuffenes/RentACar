using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rental,CarContext> , IRentalDal
{
    public List<RentalDetailDto> GetRentalDetail()
    {
        using (CarContext context = new CarContext())
        {
            var result = from x in context.Rentals
                         join c in context.Cars
                             on x.CarId equals c.Id
                         join u in context.Users
                             on x.CustomerId equals u.Id
                         join b in context.Brands
                             on c.Id equals b.Id
                         select new RentalDetailDto()
                         {
                             Id = x.Id,
                             BrandName = b.Name,
                             FirstName = u.FirstName,
                             LastName = u.LastName,
                         };
            return result.ToList();
               
        }
    }
}