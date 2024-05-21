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
}


//   if (car.Description.Length >= 2 && car.DailyPrice >0) 
// {
//            _cardal.Add(car);
//            Console.WriteLine("Yeni Car Eklendi.");

//        }
//        else
//{
//    Console.WriteLine("Car DailyPrice 0'dan büyük ve   description min iki karakter olmalıdır.");


//}
