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



        Task<List<Listing>> GetByCategory(int categoryId, string city, string userId);

        Task<List<Listing>> GetBySearchTerm(string searchTerm, string city, string userId);


        Task<List<Listing>> GetMostRecent(string region, string userId);

        // Get the pickup information for a listing.
        Task<Listing> GetPickupInfo(Guid id);

        // Get the list of Listings that the user has purchased
        Task<List<Listing>> GetMyPurchases(string buyerId);

        // Get the list of Listings that the user has posted
        Task<List<Listing>> GetMyListings(string userId, string status);

        Task<List<Listing>> GetAllMyListings(string userId);

        Task<Listing> GetListingWithSeller(Guid id); // Get a Listing and the Sellers information

        /// <summary>
        /// Change the Transaction status of the listing.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task ChangeTransactionStatus(Guid id, string status, string buyerId); //Change Transaction Status to Pending

    }
}
