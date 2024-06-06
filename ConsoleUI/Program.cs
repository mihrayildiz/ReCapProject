// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

Console.WriteLine("Hello, World!");

//CarTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());

    foreach (var car in carManager.GetAll().Data)
    {
        Console.WriteLine(car.Description);
    }



    Console.WriteLine("\n GetById :");
    Car carById = carManager.GetById(2).Data;

    Console.WriteLine(carById.Description);


    Console.WriteLine("\n GetCarsByBrandId : ");
    foreach (var car in carManager.GetCarsByBrandId(1).Data)
    {
        Console.WriteLine(car.BrandId + " " + car.Description);
    }



    Console.WriteLine("\n GetCarsByColorId : ");
    foreach (var car in carManager.GetCarsByColorId(1).Data)
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


    Console.WriteLine("\n Car detail : ");
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(car.CarName + " " + car.ColorName + " " + car.BrandName);
    }
}

//BrandTest();

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.GetBrandAdd(new Brand
    {
        Name = "MERCEDES"
    });
}

//ColoTest();

static void ColoTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    //colorManager.GetColorAdd(new Color { Name = "Siyah" });

    foreach (var color in colorManager.GetColorList())
    {
        Console.WriteLine(color.Name);
    }
}