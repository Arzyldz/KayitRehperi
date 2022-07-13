using Autofac;
using KayitRehperi.Core.Repositories;
using KayitRehperi.Core.Services;
using KayitRehperi.Core.UnitOfWorks;
using KayitRehperi.Repository;
using KayitRehperi.Repository.Repositories;
using KayitRehperi.Repository.UnitOfWorks;
using KayitRehperi.Service.Mapping;
using KayitRehperi.Service.Services;
using System.Reflection;
using Module = Autofac.Module;
namespace KayitRehperi.API.Modules
{
    public class RepoServiceModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();



            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppIdentityDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
