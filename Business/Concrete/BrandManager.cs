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

        public void Add(Brand brand)
        {
            if(brand.BrandName.Length>2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Brand name must be greater than 2 characters");
            }
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
    }
}
