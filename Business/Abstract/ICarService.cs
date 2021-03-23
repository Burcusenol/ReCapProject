using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandid);
        List<Car> GetCarsByColorId(int colorid);
        void Add(Car car);
    }
}
