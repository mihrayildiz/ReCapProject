﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class Car : IEntity
{

    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public int ModelYear { get; set; }
    public int DailyPrice { get; set; }
    public string Description { get; set; }

    public string CarName { get; set; }



    // Bir arabanın birden fazla resmi olabilir
    public List<CarImage> Images { get; set; } = new List<CarImage>();

}
