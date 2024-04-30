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
        Car car = _cardal.GetById(id);
        return car;
    }
}
