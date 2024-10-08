﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business;

public class BusinessRules
{
    public static IResult Run(params IResult[] logics)
    {
     foreach (var logic in logics)
        {
            if (!logic.Success)  //eğer başarılı değilse business code geçilmemiştir.
            {
                return logic; //geçilemeyen business code hangisi ise onu ver.
            }
        }
        return null;
    }
}
