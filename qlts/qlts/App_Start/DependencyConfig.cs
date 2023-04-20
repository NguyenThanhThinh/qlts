using Autofac.Integration.Mvc;
using Autofac;
using oclockvn.Repository;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using qlts.Datas;

namespace qlts
{
    public class DependencyConfig
    {
        public static IContainer Container { get; private set; }

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.Register(t => new UnitOfWork(new AppDbContext())).As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Store"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Handler"))
                .AsImplementedInterfaces();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            Container = container;
        }
    }
}