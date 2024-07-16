using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public  class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;

    public CustomerManager(ICustomerDal customerDal)
    {
        _customerDal = customerDal;
    }

    public IResult Add(Customer customer)
    {
        _customerDal.Add(customer);
        return new SuccesResult(Messages.CustomerAdded);
    }

    public IDataResult<List<Customer>> GetCustomerAll()
    {
        return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(), Messages.GetCustomerAll);
    }

    public IResult Update(Customer customer)
    {
       var updatedItem = _customerDal.Get(c=>c.UserId == customer.UserId);
       updatedItem.CompanyName = customer.CompanyName;
        _customerDal.Update(updatedItem);       
        return new SuccesResult("ok");
    }
}


//{
//    "data": [
//        {
//            "userId": "1",
//            "companyName": "Lösev Vakfı"
//        },
//        {
//    "userId": "2",
//            "companyName": "Darüşşafaka"
//        },
//        {
//    "userId": "3",
//            "companyName": "Adalet Bakanlığı"
//        }
//    ],