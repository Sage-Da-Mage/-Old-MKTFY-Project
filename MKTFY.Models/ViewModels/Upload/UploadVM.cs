using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Upload
{
    /// <summary>
    /// The VM class for Uploads
    /// </summary>
    public class UploadVM
    {

        /// <summary>
        /// The empty constructor for UploadVm
        /// </summary>
        public UploadVM() { }

        /// <summary>
        /// The UploadVM constructor taking in an Upload
        /// </summary>
        /// <param name="src"></param>
        public UploadVM(Entities.Upload src)
        {
            Id = src.Id;
            Url = src.Url;
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
    }
}
