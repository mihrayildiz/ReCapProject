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
    public static string CustomerAdded = "Customer Added";
    public static string GetCustomerAll = "Customer Listed";
    public static string AddNotRental = "Rental not ";
    public static string CarRentalNot = "Rental not ";
    public static string CarRental = "Rental  ";
    internal static string BrandNameExixts = "Bu isimde brand bulunuyor ekleme yapılamaz";
    internal static string BrandListed = "Markalar listelendi";
    public static string DirectoryNotFoundException = "Görsel bulunamaı";


    public static string AuthorizationDenied = "Yetkiniz yok";

    public static string UserNotFound = "Kullanıcı bulunamadı";
    public static string PasswordError = "Şifre hatalı";
    public static string SuccessfulLogin = "Sisteme giriş başarılı";
    public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
    public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
    public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
}
