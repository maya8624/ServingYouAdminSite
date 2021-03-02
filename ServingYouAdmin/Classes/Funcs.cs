
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace ServingyouAdmin.Classes
{
    public class Funcs: IFuncs
    {
        private readonly IConfiguration configuration;
        private readonly IAmazonS3 s3Client;        
        private readonly RegionEndpoint bucketRegion = RegionEndpoint.APSoutheast2;

        public Funcs(IConfiguration configuration)
        {
            this.configuration = configuration;
            s3Client = new AmazonS3Client(GetCredentials(), bucketRegion);            
        }

        private AWSCredentials GetCredentials()
        {
            var awsCredentials = new BasicAWSCredentials(
                                    configuration["AWSProfile:AccessKey"], 
                                    configuration["AWSProfile:SecretKey"]);

            return awsCredentials;
        }

        private MenuApi FormMenuApiData(Menu menu)
        {
            var menuApiData = new MenuApi
            {
                MenuId = menu.Id.ToString(),
                Available = menu.Available,
                Category = Enum.GetName(typeof(MenuCategory), menu.Category),
                Description = menu.Description,
                Image = menu.Image,
                MenuName = menu.Name,
                Price = menu.Price,
                Special = menu.Special,
            };

            return menuApiData;
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);            
        }

        
        public async Task DeleteMenuFromAWSAsync(int id)
        {
            using var client = new HttpClient();
            var endPoint = $"{configuration["ApiUrls:AWSApiUrl"]}/menus/{id}";

            using var response = await client.DeleteAsync(endPoint);
            string result = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                // write log (result)
            }
        }

        public async Task PostMenuToAWSAsync(Menu menu)
        {            
            var data = SerializeObject(FormMenuApiData(menu));
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var endPoint = $"{configuration["ApiUrls:AWSApiUrl"]}/menus/";

            using var client = new HttpClient();
            using var response = await client.PostAsync(endPoint, content);
            string result = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode != HttpStatusCode.Created)
            {
                // write log (result)
            }
        }

        public async Task PutMenuToAWSAsync(Menu menu)
        {
            var data = SerializeObject(FormMenuApiData(menu));
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var endPoint = $"{configuration["ApiUrls:AWSApiUrl"]}/menus/{menu.Id}";

            using var client = new HttpClient();
            using var response = await client.PutAsync(endPoint, content);
            string result = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                // write log (result)
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, string uploadDirectory)
        {  
            string fileName = ($"{Guid.NewGuid()}_{file.FileName}");
            string filePath = Path.Combine(uploadDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
           
            return fileName;
        }

        public void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UploadFileToS3Async(string filePath, string fileName)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);
                var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = configuration["AWSS3Bucket:BucketName"],
                    FilePath = $"{filePath}/{fileName}",
                    StorageClass = S3StorageClass.Standard,
                    PartSize = long.Parse(configuration["AWSS3Bucket:FileSize"]),
                    Key = $"{configuration["AWSS3Bucket:Key"]}/{fileName}",
                    CannedACL = S3CannedACL.PublicRead
                };

                await fileTransferUtility.UploadAsync(fileTransferUtilityRequest);                
            }
            catch (AmazonS3Exception ex)
            {
                // write log 
                throw new AmazonS3Exception($"AmazonS3Exception during uploading a file to S3. Message:{ex.Message}");
            }
            catch (Exception ex)
            {
                // write log 
                throw new Exception($"Exception during uploading a file to S3. Message:{ex.Message}");                
            }
        }

        public async Task DeleteObjectInS3Async(string fileName)
        {
            try
            {
                var deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = configuration["AWSS3Bucket:BucketName"],
                    Key = $"{configuration["AWSS3Bucket:Key"]}/{fileName}",
                };
                                
                var result = await s3Client.DeleteObjectAsync(deleteObjectRequest);
            }
            catch (AmazonS3Exception e)
            {
                throw new AmazonS3Exception($"Error encountered on server when deleting an object. Message: {e.Message}");
            }
            catch (Exception e)
            {
                throw new Exception($"Unknown encountered on server when deleting an object. Message:{e.Message}");
            }
        }
    }
}
