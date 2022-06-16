using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GameCenter.Business.Helpers.FileStorage
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FileStorageService(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Task DeleteFile(string filePath, string containerName)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return Task.CompletedTask;
            }

            var fileName = Path.GetFileName(filePath);
            var fileDirectory = Path.Combine(env.WebRootPath, containerName, fileName);

            if (File.Exists(fileDirectory))
            {
                File.Delete(fileDirectory);
            }

            return Task.CompletedTask;
        }

        public async Task<string> EditFile(string containerName, IFormFile file, string filePath)
        {
            await DeleteFile(filePath, containerName);
            return await SaveFile(containerName, file);
        }

        public async Task<string> SaveFile(string containerName, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, containerName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string route = Path.Combine(folder, fileName);
            using(var ms = new MemoryStream())
            {
                await file.CopyToAsync(ms);
                var content = ms.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }

            var url = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            var routeForDb = Path.Combine(url, containerName, fileName).Replace("\\", "/");

            return routeForDb;
        }
    }
}
