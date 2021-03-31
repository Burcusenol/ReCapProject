using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IResult Insert(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
