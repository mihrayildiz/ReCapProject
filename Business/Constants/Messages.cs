using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants;

public static class Messages
{
    public static string CarAdded = "Car Added";
    public static string ColorAdded = "Color Added";
    public static string CarNotAdded = "Car Not Added becaue Car description must be big two characters";
    public static string DailyPriceBigZero = "DailyPrice must be zero";
    public static string GetDeleteById = "Your selection has been deleted";
    public static string GetUpdateById = "Your selection has been updated";
    public static string CarsListed = "Cars Listed";
    public static string GetColorList = "Colors Listed";
    public static string GetBrandAdd = "Brand Added";
    public static string GetBrandNotAdd = "Brand Not Added because brandname is not be tree characters";


}
