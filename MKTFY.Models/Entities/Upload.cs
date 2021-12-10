using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// Simple Entity for storing the uploaded image(s).
    /// </summary>
    public class Upload
    {
        /// <summary>
        /// The Id used to identify/differenciate images.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The Url we use to get the image from AWS.
        /// </summary>
        [Required]
        public string Url { get; set; }


        ICollection<ListingUpload> ListingUploads { get; set; }
    }
}
