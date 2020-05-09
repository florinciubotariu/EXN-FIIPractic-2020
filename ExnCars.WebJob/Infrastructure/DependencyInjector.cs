using ExnCars.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExnCars.WebJob.Infrastructure
{
    static class DependencyInjector
    {
        public static ServiceProvider ServiceProvider { get; set; }

        public static void Initialize()
        {
            var serviceProvider = new ServiceCollection();
            DependencyMapper.MapDependencies(serviceProvider,null);
            ServiceProvider = serviceProvider.BuildServiceProvider();
        }

    }
}
