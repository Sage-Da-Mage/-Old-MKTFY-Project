using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// An entity for holding the Id of the Lising and the Id of the Upload.
    /// </summary>
    public class ListingUpload
    {
        /// <summary>
        /// The Listing Id that the upload is connected to.
        /// </summary>
        public Guid ListingId { get; set; }
        
        /// <summary>
        /// The Upload Id that is connected to the Listing.
        /// </summary>
        public Guid UploadId { get; set; }

    }
}
