using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class RentalsDto : IDto
{
    public string BrandName { get; set; }
    public string CustomerName { get; set; }  //Customer id = firstname +lastname

    public DateTime RentDate { get; set; }  
    public DateTime? ReturnDate { get; set; }
}
