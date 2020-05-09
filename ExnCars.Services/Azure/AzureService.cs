using ExnCars.Services.Azure.Dto;
using ExnCars.Services.Vehicles.Dto;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ExnCars.Services.Azure
{
    class AzureService : IAzureService
    {

        private readonly string connectionString;

        public AzureService()
        {
            connectionString = "DefaultEndpointsProtocol=https;AccountName=exnstorage;AccountKey=9my2ak33qDJiicQcCuI481TKOKp8pVv0QbMXUVl75/1TElbFmWZqckeohuVuZQTfBixblR4/6qZxHxBWIM6dZw==;EndpointSuffix=core.windows.net";
        }

        public UploadResult Upload(ContainerType containerType,Stream stream, string fileName)
        {

            var containerName = GetEnumDescription(containerType);
            var container = GetContainer(containerName);

            container.CreateIfNotExistsAsync().GetAwaiter().GetResult();

            var newBlobRef = container.GetBlockBlobReference($"{fileName}.png");

            newBlobRef.Properties.ContentType = "image/png";

            newBlobRef.UploadFromStreamAsync(stream).GetAwaiter().GetResult();

            return new UploadResult
            {
                FileName = fileName,
                FullPath = newBlobRef.Uri.AbsoluteUri,
            };
        }

        public void PushMessageIntoQueue(string message)
        {
            try
            {
                var queueName = "registration";

                var account = CloudStorageAccount.Parse(connectionString);
                var client = account.CreateCloudQueueClient();
                var queue = client.GetQueueReference(queueName);
                queue.CreateIfNotExistsAsync().GetAwaiter().GetResult();
                var queueMessage = new CloudQueueMessage(message);
                queue.AddMessageAsync(queueMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public string PopUpFromQueue()
        {
            var queueName = "registration";
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudQueueClient();
            var queue = client.GetQueueReference(queueName);

            CloudQueueMessage receivedMessage = queue.GetMessageAsync().GetAwaiter().GetResult();
            return receivedMessage.AsString;
        }

        public void Delete(string fullPath)
        {
            var container = GetContainer("vehiclephoto");
            var fileNameSplitter = fullPath.Split('/');
            var fileName = fileNameSplitter[fileNameSplitter.Length - 1];
            if (container.ExistsAsync().GetAwaiter().GetResult())
            {
                var blobRef = container.GetBlockBlobReference(fileName);
                blobRef.DeleteIfExistsAsync().GetAwaiter().GetResult();
            }
        }

        private CloudBlobContainer GetContainer(string containerName) 
        {
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            return container;
        }

        private string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0? attributes[0].Description: value.ToString().ToLower();
        }

    }
}
