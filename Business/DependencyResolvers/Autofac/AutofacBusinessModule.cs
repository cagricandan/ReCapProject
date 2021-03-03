using Autofac;
using Business.Abstract;
using Business.Concrate;
using DataAccess.Concrate.EntityFramework;
using DataAccess.InMemory.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

        }

    }
}
