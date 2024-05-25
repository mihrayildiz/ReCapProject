using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }


    public void GetBrandAdd(Brand brand)
    {
        if (brand.Name.Length < 3)
        {
            Console.WriteLine("Brand ismi üç karakterden az olamaz!!");
        }
        else
        {
            _brandDal.Add(brand);
            Console.WriteLine("Brand eklendi");
        }

    }
}



