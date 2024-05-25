using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

    public void NameMinTwoCharacters(Car car)
    {
        if (car.Description.Length >= 2) 
        {
            _cardal.Add(car);
            Console.WriteLine("Yeni Car Eklendi.");

        }
        else
        {
            Console.WriteLine("Car description min iki karakter olmalıdır.");
           
           
        }
       // return;
    }

    public void DailyPriceBigZero(Car car)
    {
        if (car.DailyPrice >0)
        {
            _cardal.Add(car);
            Console.WriteLine("Yeni Car Eklendi.");

        }
        else
        {
            Console.WriteLine("Car DailyPrice 0'dan büyük  olmalıdır.");
           

        }
        //return;
    }

    public void GetDeleteById(int id)
    {

        var deletedItem = _cardal.Get( c => c.Id == id);
        _cardal.Delete(deletedItem);

    }

    public void GetUpdateById(Car car)
    {
        var updatedItem = _cardal.Get(c =>c.Id == car.Id);

        updatedItem.DailyPrice = car.DailyPrice;
        updatedItem.ColorId = car.ColorId;
        updatedItem.Description = car.Description;
        updatedItem.ModelYear = car.ModelYear;
        updatedItem.BrandId = car.BrandId;
        _cardal.Update(updatedItem);
       

        
    }
}



