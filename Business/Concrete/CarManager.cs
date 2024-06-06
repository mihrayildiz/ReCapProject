using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CarManager : ICarService
{
   private readonly  ICarDal _cardal;

    public CarManager(ICarDal cardal)
    {
        _cardal = cardal;
    }

    public List<Car> GetAll()
    {
       return  _cardal.GetAll();
    }

    public Car GetById(int id)
    {
        return _cardal.Get(p =>p.Id == id);
    }

    public List<Car> GetCarsByBrandId(int brandID)
    {
        return _cardal.GetAll(c => c.BrandId == brandID);
    }

    public List<Car> GetCarsByColorId(int colorId)
    {
        return _cardal.GetAll(c => c.ColorId == colorId);   
    }

    public IResult NameMinTwoCharacters(Car car)
    {
        if (car.Description.Length >= 2) 
        {
            _cardal.Add(car);
            //Console.WriteLine("Yeni Car Eklendi."); magic strnig 
            return new SuccesResult(Messages.CarAdded); // bu şekilde magis stringler engellendi.

        }
        else
        {
            //Console.WriteLine("Car description min iki karakter olmalıdır.");
            return new ErrorResult(Messages.CarNotAdded);
           
           
        }
       // return;
    }

    public IResult DailyPriceBigZero(Car car)
    {
        if (car.DailyPrice >0)
        {
            _cardal.Add(car);
            return new SuccesResult(Messages.CarAdded);

        }
        else
        {
            return new ErrorResult(Messages.DailyPriceBigZero);
           

        }
        //return;
    }

    public IResult GetDeleteById(int id)
    {

        var deletedItem = _cardal.Get( c => c.Id == id);
        _cardal.Delete(deletedItem);
        return new SuccesResult(Messages.GetDeleteById);

    }

    public IResult GetUpdateById(Car car)
    {
        var updatedItem = _cardal.Get(c =>c.Id == car.Id);

        updatedItem.DailyPrice = car.DailyPrice;
        updatedItem.ColorId = car.ColorId;
        updatedItem.Description = car.Description;
        updatedItem.ModelYear = car.ModelYear;
        updatedItem.BrandId = car.BrandId;
        _cardal.Update(updatedItem);
        return new SuccesResult(Messages.GetUpdateById);

        
    }

    public List<CarDetailDto> GetCarDetails()
    {
       return  _cardal.GetCarDetails();
    }
}



