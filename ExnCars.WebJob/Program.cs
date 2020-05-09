using ExnCars.WebJob.Infrastructure;
using System;

namespace ExnCars.WebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceWorker = new ServiceWorker();
            serviceWorker.ProcessQueueMessage();
        }
    }
}
