using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICarService
{
    IDataResult< List<Car>> GetAll();

    IDataResult<Car >GetById(int id);

    IDataResult< List<Car>> GetCarsByBrandId(int brandId);

    IDataResult< List<Car>> GetCarsByColorId(int colorId);

    IResult NameMinTwoCharacters(Car car);

    IResult DailyPriceBigZero(Car car);

    IResult GetDeleteById (int id);

    IResult GetUpdateById(Car car);

    IDataResult<List<CarDetailDto>> GetCarDetails();

    IResult Add(Car car);

}
