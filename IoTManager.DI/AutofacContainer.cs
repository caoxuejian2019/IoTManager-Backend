using Autofac;
using Autofac.Extensions.DependencyInjection;
using IoTManager.DI.Infrastructures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.DI
{
    public sealed class AutofacContainer : IocContainer
    {
        private readonly IServiceCollection _services;

        public AutofacContainer(IServiceCollection services)
        {
            this._services = services;
        }

        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<IoTModel>();
            builder.Populate(this._services);
            return builder.Build();
        }

        public AutofacServiceProvider Injection(IContainer container)
        {
            return new AutofacServiceProvider(container);
        }
    }
}
