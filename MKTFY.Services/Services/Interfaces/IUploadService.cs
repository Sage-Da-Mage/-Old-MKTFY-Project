using Microsoft.AspNetCore.Http;
using MKTFY.Models.ViewModels.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IUploadService
    {

        Task<List<UploadResultVM>> UploadFiles(List<IFormFile> files);

    }
}
