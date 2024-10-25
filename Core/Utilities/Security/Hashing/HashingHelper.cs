using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing;

public class HashingHelper
{
    public static void CreatePasswordHash
        (string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;// passwordsalt bir anahtar
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //yeniden giriş yapılan passwor
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != passwordHash[i])  //dbdeki password ile karşılaştırdım.
                {
                    return false;
                }
            }
            return true;
        }
    }
}


/*passwordSalt, saklanan şifre hash'inin güvenliğini artırmak için kullanılır:
passwordSalt, aynı olan şifrelerin bile farklı hash'lerle sonuçlanmasını sağlar, 
bu da benzersiz bir hash elde edilmesini sağlar.
HMAC yöntemi, passwordSalt'ı kullanarak hash işleminin yaygın saldırılara karşı dirençli olmasını sağlar.
HMACSHA512 algoritması, passwordSalt'ı bir anahtar olarak kullanarak şifrenin hash'ini oluşturur. Bu, passwordSalt'ın sonuç hash'ini etkilemesini ve bu hash'in sadece bu belirli salt'a özel olmasını sağlar.*/