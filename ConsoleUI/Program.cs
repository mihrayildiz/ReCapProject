// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

//CarTest();

static void CarTest()
{
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
        Console.WriteLine(car.BrandId + " " + car.Description);
    }



    Console.WriteLine("\n GetCarsByColorId : ");
    foreach (var car in carManager.GetCarsByColorId(1))
    {
        Console.WriteLine(car.ColorId + " " + car.Description);
    }


    Console.WriteLine("\n NameMinTwoCharacters : ");

    carManager.NameMinTwoCharacters(new Car
    {
        Description = "MERCEDES CLA200"
    });


    Console.WriteLine("\n DailyPriceBigZero : ");

    carManager.DailyPriceBigZero(new Car
    {
        DailyPrice = 1800,
        Description = "MERCEDES CLA200"
    });


    Console.WriteLine("\n Delete : ");
    //carManager.GetDeleteById(2013);
    
    
    Console.WriteLine("\n Update : ");
    carManager.GetUpdateById(new Car
    {
        Id = 2019,
        DailyPrice = 2000,
        Description = "AUDI A6"

    });
}

CarManager carManager = new CarManager(new EfCarDal());
Console.WriteLine("\n Car detail : ");
foreach (var car in carManager.GetCarDetails())
{
    Console.WriteLine(car.CarName+ " " + car.ColorName + " " + car.BrandName);
}