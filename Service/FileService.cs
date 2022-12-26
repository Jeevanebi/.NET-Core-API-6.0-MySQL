using APIService.Models;
using APIService.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace APIService.Service
{
    public class FileService : IFileService
    {
        private readonly WebHostBuilder _webHostBuilder;

        public FileService(WebHostBuilder webHostBuilder)
        {
            _webHostBuilder = webHostBuilder;
        }
        public Task DeleteFile(string path)
        {
            throw new NotImplementedException();
        }

        public Task<Userfile> GetFile(Userfile files)
        {
            throw new NotImplementedException();
        }


        public string uploadFile(Userfile fileObj)
        {

            _context.Userfiles.Add(userfile);
            _context.SaveChangesAsync();
        }

     
    }
}
