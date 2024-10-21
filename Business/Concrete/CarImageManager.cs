using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
    private readonly ICarImageDal _carImageDal;
    private readonly IFileHelper _fileHelper;

    public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
    {
        _carImageDal = carImageDal;
        _fileHelper = fileHelper;
    }

    public IDataResult<List<CarImage>> GetAll()
    {
        return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll());
    }

    public IResult Add(IFormFile file, CarImage carImage)
    {
        IResult result = BusinessRules.Run(CheckIfCounfCarImage(carImage));

        if (result != null)
        {
            return result;
        }

        string guid = _fileHelper.Add(file); //guid ile path oluşturdum yani utilitis kullanıldı
        carImage.ImagePath = guid;
        carImage.Date = DateTime.Now;


        _carImageDal.Add(carImage); //ekleme
        return new SuccesResult();

    }

    public IResult Delete(CarImage carIMage)
    {
        _carImageDal.Delete(carIMage);
        _fileHelper.Delete(carIMage.ImagePath);

        return new SuccesResult();
    }

    public IResult Update(IFormFile file,CarImage carIMage)
    {
        _fileHelper.Update(file, carIMage.ImagePath);
        _carImageDal.Update(carIMage);
        
        return new SuccesResult();
    }

    private IResult CheckIfCounfCarImage(CarImage carImage)
    {
       if( _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
        {
            return new ErrorResult();
        }
        else
        {
            return new SuccesResult();
        }

    }
}
