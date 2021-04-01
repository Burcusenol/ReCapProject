using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal: EfEntityRepositoryBase<Rental, CarDbContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarDbContext context = new CarDbContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.Id equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             join r in context.Rentals
                             on c.Id equals r.CarId
                            
                             select new RentalDetailDto
                             {
                                 ModelName = c.ModelName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 RentDate = r.RentDate,
                                 DailyPrice = c.DailyPrice

                             };
                return result.ToList();





            }





        }

    }
}
