
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Security.JWT;
using Core.Utilities.Security.JWT;
using System.Reflection.Metadata.Ecma335;
using Core.Utilities.Security.Hashing;
using Business.Constants;

namespace Business.Concrete;

public class AuthManager : IAuthService
{
    IUserService _userService;
    ITokenHelper _tokenhelper;

    public AuthManager(IUserService userService, ITokenHelper tokenhelper)
    {
        _userService = userService;
        _tokenhelper = tokenhelper;
    }

    public IDataResult<AccessToken> CreateAccessToken(User user)
    {
      var claims = _userService.GetClaims(user);
      var accesstoken =   _tokenhelper.CreateToken(user, claims);
      return new SuccesDataResult<AccessToken>(accesstoken, Messages.AccessTokenCreated);


    }

    public IResult UserExists(string email)
    {
        var check = _userService.GetByEmail(email);

        if(check != null)
        {
            return new ErrorResult(Messages.UserAlreadyExists);
        }

        return new SuccesResult(Messages.UserNotFound);
    }

    public IDataResult<User> Login(UserForLoginDto userForLogin)
    {
        //user kontrol
        var userToCheck = _userService.GetByEmail(userForLogin.Email);

        if (userToCheck == null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        //yanlış şifre girilmiş olması ihtimali
        if (!HashingHelper.VerifyPasswordHash(userForLogin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccesDataResult<User>(userToCheck, Messages.SuccessfulLogin);



    }

    public IDataResult<User> Register(UserForRegisterDto userForRegister, string password)
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

        var user = new User
        {
            Email = userForRegister.Email,
            FirstName = userForRegister.FirstName,
            LastName = userForRegister.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true

        };

        _userService.Add(user); //user eklendi
        return new SuccesDataResult<User>(Messages.UserRegistered);
    }



}

