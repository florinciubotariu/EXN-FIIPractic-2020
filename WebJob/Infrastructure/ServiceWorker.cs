using ExnCars.Services.Azure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebJob.Infrastructure
{
    internal class ServiceWorker
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
           var message = azureService.PopUpMessageFromQueueAsync(QueueType.NewItem);
            Console.WriteLine(message);
        }
    }
}
