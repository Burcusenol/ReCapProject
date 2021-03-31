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
                var result = from r in context.Rentals
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CustomerId = cu.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CarId = car.Id,
                                 BrandName = b.BrandName,
                                 ModelName = car.ModelName,
                                 ColorName = color.ColorName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                        return result.ToList();
            }




            
        }

    }
}
