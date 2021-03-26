using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();
            //GetById();
            CarDetails();
        }

        private static void GetById()
        {
            Console.WriteLine(new ColorManager(new EfColorDal()).GetById(3).ColorName);
            Console.WriteLine(new CarManager(new EfCarDal()).GetById(1).DailyPrice);
            Console.WriteLine(new BrandManager(new EfBrandDal()).GetById(4).BrandName);
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car : " + car.CarName + " -- Price : " + car.DailyPrice + " -- Brand Name : " + car.BrandName + " -- Color Name : " + car.ColorName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Insert(new Color { ColorName = "White" });
            Console.WriteLine("Color added.");
            colorManager.Update(new Color { ColorId = 1008, ColorName = "Red" });
            Console.WriteLine("Color updated.");
            colorManager.Delete(new Color { ColorId = 1008 });
            Console.WriteLine("Color deleted.");

            Console.WriteLine("---List of Color---");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Insert(new Brand { BrandId = 12, BrandName = "XX" });
            Console.WriteLine("Brand added.");
            brandManager.Update(new Brand { BrandId = 12, BrandName = "Xa" });
            Console.WriteLine("Brand updated.");
            brandManager.Delete(new Brand { BrandId = 12 });
            Console.WriteLine("Brand deleted.");

            Console.WriteLine("---List of Brand---");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Insert(new Car { BrandId = 2, ColorId = 4, DailyPrice = 456000, Description = "Q3", ModelYear = 2021 });
            Console.WriteLine("Car added.");
            carManager.Update(new Car { Id=1, BrandId=2, ColorId = 8 , DailyPrice=456600, Description="Q3", ModelYear=2021});
            Console.WriteLine("Car updated");
            carManager.Delete(new Car { Id=1});
            Console.WriteLine("Car deleted");

            Console.WriteLine("---List of Car---");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car : " + car.Description + " -- Price : " + car.DailyPrice);
            }
        }
    }
}
