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
            //CarDetails();
            //RentalDetails();


            CustomerTest();
        }

        private static void CustomerTest()
        {

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Insert(new Customer { CustomerId = 1, UserId = 2, CompanyName = "A Şirketi", FirstName="Ayşe", LastName="Ay", Email="ayseay@gmail.com", Id=1, Password="123456789"});
            customerManager.Insert(new Customer { CustomerId = 2, UserId = 1, CompanyName = "B Şirketi", FirstName="Ali", LastName="Veli", Email="aliveli@gmail.com", Password="987654321", Id=2});

           
        } 

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            
            if(result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car : " + car.CarName + " -- Price : " + car.DailyPrice + " -- Brand Name : " + car.BrandName + " -- Color Name : " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
        }

        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Car : " + rental.ModelName + " -- Brand Name: " + rental.BrandName + " -- Color Name : " + rental.ColorName + " -- First Name : " + rental.FirstName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
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

            var result = colorManager.GetAll();
            if(result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
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

            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
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

            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car : " + car.Description + " -- Price : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.ReadLine();
            
        }
    }
}
