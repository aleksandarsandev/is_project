using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Service.Implementation
{
    using Azure.Storage.Blobs;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using System.Threading.Tasks;

    public class BlobService
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public BlobService(IConfiguration configuration)
        {
            _connectionString = configuration["AzureBlobStorage:ConnectionString"];
            _containerName = configuration["AzureBlobStorage:ContainerName"];
        }

        public async Task<Stream> GetTemplateStreamAsync(string blobName)
        {
            var blobServiceClient = new BlobServiceClient(_connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            return await blobClient.OpenReadAsync();
        }
    }
}
