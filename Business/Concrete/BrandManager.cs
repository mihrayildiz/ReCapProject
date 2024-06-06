using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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


    public IResult GetBrandAdd(Brand brand)
    {
        if (brand.Name.Length < 3)
        {
            return new ErrorResult(Messages.GetBrandNotAdd);

        }
        else
        {
            _brandDal.Add(brand);
            return new SuccesResult(Messages.GetBrandAdd);
        }

    }
}



