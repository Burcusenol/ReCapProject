using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) 
                + _carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath;

            IResult result = BusinessRules.Run(FileHelper.Delete(oldpath));
            if(result!=null)
            {
                return result;
            }
            FileHelper.Delete(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfAnyCarImageExists(carId));
            if(result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.CheckIfAnyCarImageExists);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfAnyCarImageExists(carId).Data);
            
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ı=>ı.CarImageId==id));
        }

       [ValidationAspect(typeof(CarImageValidator))]
        public IResult Insert(IFormFile file,CarImage carImage)
        {

            IResult result = BusinessRules.Run(CheckCarImageLımıted(carImage.CarId));
            if(result!=null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.CreationDate = DateTime.Now;
            _carImageDal.Insert(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

      
        public IResult Update(IFormFile file,CarImage carImage)
        {
            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) 
                + _carImageDal.Get(p => p.CarImageId== carImage.CarImageId).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath,file);
            carImage.CreationDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageLımıted(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if(result>5)
            {
                return new ErrorResult(Messages.CarImageLımıted);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfAnyCarImageExists(int carId)
        {
            string path = @"\Images\DefaultCarImage.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
            }

            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, ImagePath = path, CreationDate = DateTime.Now });

            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }



}
