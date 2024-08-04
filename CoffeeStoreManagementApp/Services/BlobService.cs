using CoffeeStoreManagementApp.Services.Interfaces;
using Azure.Storage.Blobs;

namespace CoffeeStoreManagementApp.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public BlobService()
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=senablobstorage;AccountKey=6DxOlRfp/yXDPbVzQz8RFKzFDagjwBI+qVQX38baMQ6ECGdiqxyApBpTtpNX2ffIvJN69aSbGI4l+AStZvuoFA==;EndpointSuffix=core.windows.net";
            _blobServiceClient = new BlobServiceClient(connectionString);
            _containerName = "sena-blob-container";
        }


        public async Task<string> UploadImageAsync(IFormFile file, string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);

            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);

            return blobClient.Uri.ToString();
        }



        public async Task<string> GetBlobUrlAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(blobName);
            return blobClient.Uri.ToString();
        }

    }
}
