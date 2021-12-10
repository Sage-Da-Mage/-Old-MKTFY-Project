using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IUploadRepository
    {
            Task<Upload> Create(Upload src);                        // Create a new upload
            Task<Upload> Get(Guid id);                              // Get a single existing upload by its id
             Task Delete(Guid id);                                  // Delete an upload

            Task<List<ListingUpload>> GetListingUploads(Guid id);  //Get a list of ListingUploads for a specific Listing Id

    }
}
