using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;

public class CarImage : IEntity
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string ImagePath { get; set; }
   
    public DateTime Date { get;   set; }  
    public Car Car{ get; set; }

    //public CarImage()
    //{
    //    Date = DateTime.Now;
    //}
}



//public DateTime Date { get; set; }  = DateTime.Now; olmaz neden? class oluştuğu tarihi imagel verir . Fakat bu yaklaşım her nesne oluşturulduğunda değil, sınıfın tanımlandığı anda bir kez çağrılır.
