using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Insert(Brand brand)
        {
            if(brand.BrandName.Length>2)
            {
                _brandDal.Insert(brand);
            }
            else
            {
                Console.WriteLine("Brand name must be greater than 2 characters");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandid)
        {
            return _brandDal.GetById(brandid);
        }


        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
