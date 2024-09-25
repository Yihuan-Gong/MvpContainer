//using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfMadeContainerExample;

namespace MvpContainer
{
    public class PresenterFactory
    {
        public TPresenter Create<TPresenter, TView>(TView view)
        where TPresenter : class
        where TView : class
        {
            var implementationType = GetImplementationType<TPresenter>();
            if (implementationType == null)
            {
                throw new InvalidOperationException($"No implementation type registered for {typeof(TPresenter).FullName}");
            }
            return (TPresenter)Activator.CreateInstance(implementationType, view);
            //return (TPresenter)ActivatorUtilities.CreateInstance(Program.ServiceProvider, implementationType, view);
        }

        private Type GetImplementationType<TInterface>()
        {
            var descriptor = Service.ServiceCollection.FirstOrDefault(
                s => s.ServiceType == typeof(TInterface));

            if (descriptor == null)
            {
                return null;
            }

            if (descriptor.ImplementationType != null)
            {
                return descriptor.ImplementationType;
            }

            if (descriptor.ImplementationFactory != null)
            {
                // 如果使用了工厂方法，需要额外处理
                throw new InvalidOperationException($"Cannot determine implementation type for {typeof(TInterface).FullName}");
            }

            if (descriptor.ImplementationInstance != null)
            {
                return descriptor.ImplementationInstance.GetType();
            }

            return null;
        }
    }
}
