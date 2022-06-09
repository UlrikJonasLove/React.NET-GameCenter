using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Business.Helpers.FileStorage
{
    public interface IFileStorageService
    {
        Task DeleteFile(string filePath, string containerName);
        Task<string> SaveFile(string containerName, IFormFile file);
        Task<string> EditFile(string containerName, IFormFile file, string filePath);
    }
}
