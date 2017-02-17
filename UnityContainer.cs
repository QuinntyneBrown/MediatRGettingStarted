using MediatR;
using Microsoft.Practices.Unity;
using System;
using System.Linq;

namespace MediatRGettingStarted
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterInstance(Console.Out);

            container.RegisterType<IMediator, Mediator>();
            container.RegisterTypes(AllClasses.FromAssemblies(typeof(UnityConfiguration).Assembly), WithMappings.FromAllInterfaces, GetName, GetLifetimeManager);
            container.RegisterInstance<SingleInstanceFactory>(t => container.IsRegistered(t) ? container.Resolve(t) : null);
            container.RegisterInstance<MultiInstanceFactory>(t => container.ResolveAll(t));
            var mediator = container.Resolve<IMediator>();
            return container;
        }

        static bool IsNotificationHandler(Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && (x.GetGenericTypeDefinition() == typeof(INotificationHandler<>) || x.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>)));
        }

        static LifetimeManager GetLifetimeManager(Type type)
        {
            return IsNotificationHandler(type) ? new ContainerControlledLifetimeManager() : null;
        }

        static string GetName(Type type)
        {
            return IsNotificationHandler(type) ? string.Format("HandlerFor" + type.Name) : string.Empty;
        }
    }
}
