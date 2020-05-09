using System;
using WebJob.Infrastructure;

namespace WebJob
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            var serviceWorker = new ServiceWorker();
            serviceWorker.ProcessQueueMessage();
        }
    }
}
