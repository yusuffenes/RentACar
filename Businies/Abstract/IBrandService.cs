using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    IDataResult<List<Brand>> GetBrands();
    IDataResult<List<Brand>> GetAllByBrand(int brandId);
    IResult Add(Brand brand);
    IResult Update(Brand brand);
    IResult Delete(Brand brand);
}