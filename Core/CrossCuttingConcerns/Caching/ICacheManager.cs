using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheManager
{
    void Add(string key, object value,int duration); //cache eklenebilir.
    T Get<T>(string key); //tek bir nesenede dönebilir birden fzla nesnede dönebilir
    object Get(string key); //tip döüşümü yapmak gerekir

    bool IsAdd(string key); //cach te var mı

    void Remove(string key);

    void RemoveByPattern(string pattern);  //başı sonu önrmli değil içinde category olanlar gibi, ismi et ile başlayanlar demek gibi

}
 