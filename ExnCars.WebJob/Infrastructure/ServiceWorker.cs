using ExnCars.Services.Azure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ExnCars.WebJob.Infrastructure
{
    class ServiceWorker
    {
        private readonly IAzureService azureService;

        public ServiceWorker()
        {
            DependencyInjector.Initialize();
            var serviceProvider = DependencyInjector.ServiceProvider;
            azureService = serviceProvider.GetService<IAzureService>();
        }

        public void ProcessQueueMessage()
        {
            var message = azureService.PopUpFromQueue();
            Console.WriteLine(message);
        }
    }
}
