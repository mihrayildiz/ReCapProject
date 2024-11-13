using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC;

public static class ServiceTool
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }


}



/* IServiceCollection türünden services parametresini alarak, 
 * uygulamanın tüm servislerinin yapılandırmasını tamamlayıp bir ServiceProvider(servis sağlayıcı) 
 * oluşturmak ve onu statik olarak saklamaktır.
    Bu sayede, diğer sınıflar ServiceTool üzerinden ServiceProvider'a erişebilir.
ServiceTool sınıfı üzerinden servislere erişebilir.
IServiceCollection arayüzü .NET’in temel bir parçasıdır ve Microsoft.Extensions.DependencyInjection ad alanında bulunur. */