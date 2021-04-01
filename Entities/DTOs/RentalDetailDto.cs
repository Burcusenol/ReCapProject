using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
            
            public string BrandName { get; set; }
            public string ModelName { get; set; }
            public string ColorName { get; set; }
            public decimal  DailyPrice { get; set; }
            public DateTime RentDate { get; set; }
       

    }
}
