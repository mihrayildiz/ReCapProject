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

public class RentalManager : IRentalService
{
    private readonly IRentalDal _rentalDal;

    public RentalManager(IRentalDal rentalDal)
    {
        _rentalDal = rentalDal;
    }

    public IResult AddRental(Rental rental)
    {
        var result = _rentalDal.GetAll(r => r.CarId == rental.CarId).ToList()
            .FirstOrDefault(r => r.ReturnDate == null);
           

        if (result != null) // eğer null değil yani bir tane bile data tutuyorsa kiralama yapılamaz.
        {
            return new ErrorResult(Messages.CarRentalNot);
            
          }
        else
        {
            _rentalDal.Add(rental);
            return new SuccesResult(Messages.CarRental);
        }

        
    }
}

