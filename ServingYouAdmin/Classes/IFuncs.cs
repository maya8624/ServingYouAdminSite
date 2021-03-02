using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ServingYouAdmin.Models;

namespace ServingyouAdmin.Classes
{
    public interface IFuncs
    {
        Task DeleteMenuFromAWSAsync(int id);

        Task PostMenuToAWSAsync(Menu menu);

        Task PutMenuToAWSAsync(Menu menu);

        Task UploadFileToS3Async(string filePath, string fileName);

        Task<string> UploadFileAsync(IFormFile file, string uploadDirectory);

        Task DeleteObjectInS3Async(string fileName);
        
        void DeleteFile(string filePath);

        string SerializeObject(object obj);
    }
}
