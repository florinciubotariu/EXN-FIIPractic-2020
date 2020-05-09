using ExnCars.Services.Azure.Dto;
using ExnCars.Services.Vehicles.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExnCars.Services.Azure
{
    public interface IAzureService
    {
        UploadResult Upload(ContainerType containerType, Stream stream, string fileName);
        void PushMessageIntoQueue(string message);
        string PopUpFromQueue();
        void Delete(string fullPath);
    }
} 
