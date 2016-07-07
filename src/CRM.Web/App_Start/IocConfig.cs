using AspMvc.Infrastructure.IoC.CastleWindsor;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace CRM.Web
{
    public class IocConfig
    {
        public static void Configure()
        {
            var c = CreateContainer();
            DependencyResolver.SetResolver(new WindsorDependencyResolver(c));
        }

        private static IWindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();

            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies()
              .Where(f =>
                !f.FullName.StartsWith("Castle.")
                && !f.FullName.StartsWith("System")
                && !f.FullName.StartsWith("MvcContrib")
                && !f.FullName.StartsWith("Microsoft"));

            RegisterAssemblies(container, assemblies);
            return container;
        }

        public static void RegisterAssemblies(IWindsorContainer container, IEnumerable<Assembly> assembliesOfTypesToRegister)
        {
            foreach (var assembly in assembliesOfTypesToRegister)
            {
                container.Register(Classes.FromAssembly(assembly)
                  .BasedOn<IController>()
                  .If(c => c.Name.EndsWith("Controller"))
                  .LifestylePerWebRequest());

                container.Register(Classes.FromAssembly(assembly)
                  .IncludeNonPublicTypes().AllowMultipleMatches()
                  .Pick()
                  .WithService.AllInterfaces()
                  .LifestylePerWebRequest());
            }
        }
    }
}