using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT;

public  class TokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
    public int AccessTokenExpiration { get; set; }
}

//appsetting dosyasındaki JWT için var olan JSON bililerinin okunduğu ve değer verildi nesne.