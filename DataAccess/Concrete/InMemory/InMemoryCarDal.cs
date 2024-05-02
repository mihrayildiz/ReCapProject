using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory;

public class InMemoryCarDal : ICarDal
{

    List<Car> _cars;

    public InMemoryCarDal()
    {
        _cars = new List<Car>
        { 
          new Car { Id= 1, BrandId= 1, ColorId = 1, ModelYear = 2021, DailyPrice = 600, Description = "RENAULT CLIO"},  //
          new Car { Id= 2, BrandId= 1, ColorId = 1, ModelYear = 2021, DailyPrice = 600, Description= "RENAULT MEGANE"},//
          new Car { Id= 3, BrandId= 2, ColorId = 2, ModelYear = 2021, DailyPrice = 1050, Description="MERCEDES VITO"},//
          new Car { Id= 4, BrandId= 2, ColorId = 1, ModelYear = 2021, DailyPrice = 1250, Description = "MERCEDES CLA200"},//
          new Car { Id= 5, BrandId= 3, ColorId = 1, ModelYear = 2021, DailyPrice = 1350, Description = "AUDI A6"},//
          new Car { Id= 6, BrandId= 4, ColorId = 1, ModelYear = 2021, DailyPrice = 1050, Description ="TOYOTA COROLLA"},//

        
        };
    }

    public void Add(Car car)
    {
       _cars.Add(car);
    }

    public void Delete(Car car)
    {
        Car carToDelete =  _cars.SingleOrDefault(c =>c.Id == car.Id);
       _cars.Remove(carToDelete);
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int Id)
    {
        Car car = _cars.SingleOrDefault(car => car.Id == Id);
        return car;
    }

    public void Update(Car car)
    {
        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

        carToUpdate.BrandId = car.BrandId;
        carToUpdate.ColorId = car.ColorId;
        carToUpdate.ModelYear = car.ModelYear;
        carToUpdate.DailyPrice = car.DailyPrice;
        carToUpdate.Description = car.Description;


    }
}
