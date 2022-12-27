using APIService.Data;
using APIService.Models;
using APIService.Repository;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.IO.Compression;

namespace APIService.Service
{
    public class FileService : IFileService
    {

        private readonly ApplicationDbContext _context;

        public FileService(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public Task DeleteFile(string path)
        {
            throw new NotImplementedException();
        }

        public Task<Userfile> GetFile(Userfile files)
        {
            throw new NotImplementedException();
        }
            

        public Userfile uploadFile(CreateFile fileObj)
        {
            //var fileDataByte = ReadFile(fileObj);

            //_context.Userfiles.Add(fileDataByte);

            // _context.SaveChangesAsync();

            //return fileDataByte;

            return null;
        }

        public Userfile uploadFile(Userfile fileObj)
        {
            throw new NotImplementedException();
        }

        //protected byte[] ReadFile(CreateFile fileObj) 
        //{
        //    string untrustedFileName = Path.GetFileName(fileObj.FileData);


        //    using (var memoryStream = new MemoryStream())
        //    {
        //        fileObj.FileData.FormFile.CopyTo(memoryStream);

        //        // Upload the file if less than 2 MB
        //        if (memoryStream.Length < 2097152)
        //        {
        //            var file = new CreateFile()
        //            {
        //                Filename = untrustedFileName,
        //                FileData = memoryStream.ToArray()
        //            };

        //            _context.Userfiles.Add(file);

        //            _context.SaveChangesAsync();

        //            return file;
        //        }
        //        else
        //        {
        //           return "The file is too large.";
        //        }
        //    }
        //}
    }

}
