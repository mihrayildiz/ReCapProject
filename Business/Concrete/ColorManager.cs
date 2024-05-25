using Business.Abstract;
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

    public void GetColorAdd(Color color)
    {
        _colorDal.Add(color);
        Console.WriteLine("Color Eklendi");
    }

    public List<Color> GetColorList()
    {
      return   _colorDal.GetAll();
    }
}
