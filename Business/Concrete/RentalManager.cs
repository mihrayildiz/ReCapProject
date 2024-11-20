using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
      IResult result  =  BusinessRules.Run(CheckIfSuitableOfCarForRental(rental));

        if (result != null)
        {
            return result;
        }


        _rentalDal.Add(rental);
        return new SuccesResult(Messages.CarRental);



    }

    public IDataResult<List<RentalsDto>> GetAllRental()
    {
        return new SuccesDataResult<List<RentalsDto>>(_rentalDal.GetRentals(), Messages.GetAllRental);
    }


    //businss code
    private IResult CheckIfSuitableOfCarForRental(Rental rental)
    {
        var result = _rentalDal.GetAll(r => r.CarId == rental.CarId).ToList()
           .FirstOrDefault(r => r.ReturnDate == null);

        if (result != null) // eğer null değil yani bir tane bile data tutuyorsa kiralama yapılamaz.
        {

            return new ErrorResult(Messages.CarRentalNot);
        }

        return new SuccesResult();

    }

}

