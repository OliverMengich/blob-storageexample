using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace AzureStorageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string accountName = "oliverblobstorage";
                string accessKey = "dJ9P6aD8WoJUKD3xlp36ynFOPxPZxZU/xLRxcfuH5m14OpObMXStXTUpRqEKDXrFzP9mHj/8xwldGLddXZJ/zg==";
                StorageCredentials credentials = new StorageCredentials(accountName, accessKey);
                CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(credentials, useHttps: true);
                CloudBlobClient client = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlob = client.GetContainerReference("oliversample");
                cloudBlob.CreateIfNotExists();
                var x=cloudStorageAccount.TableStorageUri;
                
                cloudBlob.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
                CloudBlockBlob cblob = cloudBlob.GetBlockBlobReference("clothe3.jpg");
                
                using (Stream filestream = System.IO.File.OpenRead(@"C:\Users\olive\source\repos\AzureStorageExample\AzureStorageExample\Assets\clothe3.jpg"))
                {
                    cblob.UploadFromStream(filestream);
                    Console.WriteLine("Connected to the blob storage");
                }
                
            }
            catch (Exception)
            {

                Console.WriteLine("Cannot connect the container");
            }
            Console.ReadKey();
        }
    }
}
