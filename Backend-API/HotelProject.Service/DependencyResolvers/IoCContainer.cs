using Autofac;
using HotelProject.Core.Abstracts.IRepositories.Generic;
using HotelProject.Core.Abstracts.IService.Generic;
using HotelProject.Core.Abstracts.IUnitOfWorks;
using HotelProject.Repository.Repositories;
using HotelProject.Repository.Repositories.Generic;
using HotelProject.Repository.UnitOfWorks;
using HotelProject.Service.Services;
using HotelProject.Service.Services.Generic;
using System.Reflection;
using Module = Autofac.Module;

namespace HotelProject.Service.DependencyResolvers
{
    public class IoCContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            var executingAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(RoomRepository));
            var serviceAssembly = Assembly.GetAssembly(typeof(RoomService));

            // Sonu "Repository" ile biten sınıfların interfaceleri'ne otomatik olarak bağlan. Her bağlı lifetime scope için bir örnek oluştur.
            builder.RegisterAssemblyTypes(executingAssembly, repoAssembly, serviceAssembly)
                .Where(repo => repo.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            // Sonu "Service" ile biten sınıfların interfaceleri'ne otomatik olarak bağlan. Her bağlı lifetime scope için bir örnek oluştur.
            builder.RegisterAssemblyTypes(executingAssembly, repoAssembly, serviceAssembly)
                .Where(service => service.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
