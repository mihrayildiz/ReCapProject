using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
       //Brand
        builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
        builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
        
        //Car
        builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
        builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
    }
}
