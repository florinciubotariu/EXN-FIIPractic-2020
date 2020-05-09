using ExnCars.Services.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebJob.Infrastructure
{
    static class DependencyInjector
    {
        public static ServiceProvider ServiceProvider { get; set; }

        public static void Initialize()
        {
            var serviceProvider = new ServiceCollection();
            DependencyMapper.MapDependencies(serviceProvider);
            ServiceProvider = serviceProvider.BuildServiceProvider();
        }
    }
}
