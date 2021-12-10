using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Upload;

namespace MKTFY.Models.ViewModels.Listing
{

    /// <summary>
    /// This View Model is for adding a listing
    /// </summary>
    public class ListingAddVM
    {

        /// <summary>
        /// CategoryId: 1=Cars/Vehicles, 2=Furniture, 3=Electronics, 4=Real Estate
        /// Potentially add more after talking with team
        /// </summary>
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The Id of an upload.
        /// </summary>
        public List<Guid> UploadIds { get; set; }

    }
}
