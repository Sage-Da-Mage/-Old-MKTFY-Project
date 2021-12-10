using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels;
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
        Task<ListingVM> Create(ListingAddVM src, string userId);

        //Get a single existing Listing by its Id
        Task<ListingVM> Get(Guid id);

        // Get all of the Listings currently existing
        Task<List<ListingVM>> GetAll();

        //Update a currently existing Listing
        Task<ListingVM> Update(ListingUpdateVM src);

        // Delete a Listing
        Task Delete(Guid id);

        // Get a series of listings by an inputted Category
        Task<List<ListingVM>> GetByCategory(int categoryId, string region);

        // Get a series of listing based on the users previous searches/location
        Task<List<ListingVM>> GetDeals(string userId, string city);


        // Get the pickup info for a listing
        Task<ListingSellerVM> GetPickupInfo(Guid id);

        // Get a series of lisitings by an inputted string of terms.
        Task<List<ListingVM>> GetBySearchTerm(SearchCreateVM src, string region);


        // Change the StatusOfTransaction to an inputted string.
        Task ChangeTransactionStatus(Guid id, string status, string buyerId);

    }
}
