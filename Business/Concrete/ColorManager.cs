using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entities.Concrete.Color;

namespace Business.Concrete;

public class ColorManager : IColorService
{
    private readonly IColorDal _colorDal;

    public ColorManager(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public IResult GetColorAdd(Color color)
    {
        _colorDal.Add(color);
        return new SuccesResult(Messages.ColorAdded);
       
    }

    public IDataResult<List<Color>> GetColorList()
    {
        return new SuccesDataResult<List<Color>>(_colorDal.GetAll(), Messages.GetColorList) ;
    }
}
