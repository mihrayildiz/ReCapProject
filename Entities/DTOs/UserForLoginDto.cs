using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class UserForLoginDto : IDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}


//kullanıcıdan ilk olarak string olarak alırız bu değerleri daha sonra password hash işlemine girdi olarak verilir.