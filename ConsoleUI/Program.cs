// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");


CarManager carManager = new CarManager(new EfCarDal());

foreach (var car in carManager.GetAll())
{
    Console.WriteLine(car.Description);
}



Console.WriteLine("\n GetById :");
Car carById = carManager.GetById(2);

Console.WriteLine(carById.Description);








Console.WriteLine("\n GetCarsByBrandId : ");
foreach (var car in carManager.GetCarsByBrandId(1))
{
    Console.WriteLine(car.BrandId + " " +  car.Description);
}



 Console.WriteLine("\n GetCarsByColorId : ");
foreach (var car in carManager.GetCarsByColorId(1))
{
    Console.WriteLine( car.ColorId + " " +   car.Description);
}
