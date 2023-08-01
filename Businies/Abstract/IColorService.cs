using Core.Utilities.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IColorService
{
    IDataResult<List<Color>> GetColorList();
    IDataResult<List<Color>> GetAllByColorId(int colorId);
    IResult Add(Color color);
    IResult Remove(Color color);
    IResult Update(Color color);
}