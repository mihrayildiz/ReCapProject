using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

    public IDataResult<List<Brand>> GetAll()
    {
        return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
    }

    [SecuredOperation("admin,brand.add")]
    //aynı isimde ekleme yapamz
    public IResult GetBrandAdd(Brand brand)
    {

        IResult result = BusinessRules.Run(CheckIfSameNameOfBrandName(brand.Name));
        if(result != null)
        {
            return result;
        }

        if (brand.Name.Length < 3)  //AOP
        {
            return new ErrorResult(Messages.GetBrandNotAdd);

        }
        else
        {
            _brandDal.Add(brand);
            return new SuccesResult(Messages.GetBrandAdd);
        }

    }

    private IResult CheckIfSameNameOfBrandName  (string name)
    {
        var result = _brandDal.GetAll(b => b.Name == name).Any();
        
        if(result)
        {
            return new ErrorResult(Messages.BrandNameExixts);
        }

        return new SuccesResult();
    }
}



