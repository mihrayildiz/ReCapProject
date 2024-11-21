using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCampProjectDbContext>, IRentalDal
{
    public List<RentalsDto> GetRentals()
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            
            var result = from br in context.Brands
                         join cr in context.Cars
                         on br.Id equals cr.BrandId  
                         join rt in context.Rentals
                         on cr.Id equals rt.CarId
                         join cstm in context.Customers
                         on rt.CustomerId equals cstm.Id
                         select new RentalsDto
                         {
                             BrandName = br.Name,
                             CustomerName = cstm.FirstName + " " + cstm.LastName , // FirstName ve LastName birleşimi
                             RentDate = rt.RentDate,
                             ReturnDate = rt.ReturnDate
                         
                         
                         };



            return result.ToList();

        }
    }


}
