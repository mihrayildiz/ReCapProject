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
}
