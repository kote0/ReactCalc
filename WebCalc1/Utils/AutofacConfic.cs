using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using DomainModels.Repository;
using System.Web.Mvc;
using NH = DomainModels.NHibernate;

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
            builder.RegisterType<NH.OperationRepository>().As<IOperationRepository>();
            builder.RegisterType<NH.LikeRepository>().As<ILikeRepository>();
            builder.RegisterType<NH.UserRepository>().As<IUserRepository>();
            builder.RegisterType<NH.ORRepository>().As<IORepository>();
            

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}