using Autofac;
using Autofac.Integration.Mvc;
using BitirmeDRM.Core.Infrastructure;
using BitirmeDRM.Core.Repository;
using System.Web.Mvc;

namespace BitirmeDRM.UI
{
    public static class Bootstrapper
    {
        public static void RunConfig()
        {
            BuildAutofac();
        }
        private static void BuildAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MuzikRepository>().As<IMuzikRepository>();
            builder.RegisterType<KategoriRepository>().As<IKategoriRepository>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}