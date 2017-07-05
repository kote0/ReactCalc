using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using DomainModels.EF;
using DomainModels.Repository;
using System.Web.Mvc;

namespace WebCalc1
{
    public class AutofacConfic
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<DomainModels.EF.UserRepository>().As<IUserRepository>();
            builder.RegisterType<ORRepository>().As<IORepository>();
            builder.RegisterType<OperationRepository>().As<IOperationRepository>();
            builder.RegisterType<LikeRepository>().As<ILikeRepository>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}