using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Insert(Car car)
        {
            if(car.DailyPrice>0 )
            {
                _carDal.Insert(car);
            }
            else
            {
                Console.WriteLine("The daily price must be greater than zero  ");
            }
        }

        public void Delete(Car car)
        {
             _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandid)
        {
            return _carDal.GetAll(c => c.BrandId == brandid);
        }

        public List<Car> GetCarsByColorId(int colorid)
        {
            return _carDal.GetAll(c => c.ColorId == colorid);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public Car GetById(int carid)
        {
            return _carDal.GetById(carid);
        }
    }
}
