using APIService.Models;

namespace APIService.Repository
{
    public interface IFileService
    {
        Task<Userfile> GetFile(Userfile fileObj);

        string uploadFile(Userfile fileObj);

        Task DeleteFile(string path);


    }
}
