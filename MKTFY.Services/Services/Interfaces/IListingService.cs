using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IListingService
    {
        // Create a new Listing
        Task<ListingVM> Create(ListingAddVM src);

        //Get a single existing Listing by its Id
        Task<ListingVM> Get(Guid id);

        // Get all of the Listings currently existing
        Task<List<ListingVM>> GetAll();

        //Update a currently existing Listing
        Task<ListingVM> Update(ListingUpdateVM src);

        // Delete a Listing
        Task Delete(Guid id);

    }
}
