using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
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


        [SecuredOperation("car.insert,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Insert(Car car)
        {
            _carDal.Insert(car);
            return new SuccessResult(Messages.CarAdded);
             
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return  new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandid)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandid));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorid)
        {
            return  new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorid));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
             return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<Car> GetById(int carid)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==carid));
        }
    }
}
