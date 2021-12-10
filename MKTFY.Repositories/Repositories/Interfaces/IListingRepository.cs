using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories.Interfaces
{
    public interface IListingRepository
    {
        // Create a new listing
        Task<Listing> Create(Listing src);

        // Get a single existing listing by its ID
        Task<Listing> Get(Guid id);

        // Get all listings
        Task<List<Listing>> GetAll();

        // Update an existing listing
        Task<Listing> Update(Listing src);

        // Delete a listing
        Task Delete(Guid id);

        // Get the pickup information for a listing.
        Task<Listing> GetPickupInfo(Guid id);

        // ADD THE METHODS BELOW (after adding them to ListingRepository.cs):

        Task<List<Listing>> GetByCategory(int categoryId, string City);


        Task<List<Listing>> GetBySearchTerm(string searchTerm, string region);


        // GetPickupInfo(Guid id){
        // }

        // GetMyPurchases(string buyerId){
        // }

        /// <summary>
        /// Change the Transaction status of the listing.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task ChangeTransactionStatus(Guid id, string status, string buyerId); //Change Transaction Status to Pending

    }
}
