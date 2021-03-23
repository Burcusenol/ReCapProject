using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void Add(Car car)
        {
            if(car.DailyPrice>0 )
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("The daily price must be greater than zero  ");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandid)
        {
            return _carDal.GetAll(c => c.BrandId == brandid);
        }

        public List<Car> GetCarsByColorId(int colorid)
        {
            return _carDal.GetAll(c => c.ColorId == colorid);
        }
    }
}
