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
    /// The difference between this and ListingAddVM file is that
    /// it must contain any/only objects that can be updated. (i.e. no Created variable)
    /// </summary>
    public class ListingUpdateVM
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        // May want to add a check for if it is a proper categoryId in future (not a number unassigned to an id)
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
        [Required]
        public string Condition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ListingUpload> ListingUploads { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string UserId { get; set; }

    }
}
