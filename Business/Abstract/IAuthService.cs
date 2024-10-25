
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public  interface IAuthService
{
    IDataResult<User> Login(UserForLoginDto userForLogin);
    IDataResult<User> Register(UserForRegisterDto userForRegister, string password);

    IResult UserExists(string email); //bu kişi kayıtlı mı email kullanrak kontrol edeceğiz.

    IDataResult<AccessToken> CreateAccessToken(User user);

}
