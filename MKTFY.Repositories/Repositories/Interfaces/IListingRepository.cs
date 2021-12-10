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

        // GetbyCategory (int category Id, string City, string userId){
        //}

        // GetBySearchTerm(string searchTermLowerCase, string City, string userId){
        //}

        // GetPickupInfo(Guid id){
        // }

        // GetMyPurchases(string buyerId){
        // }

        // ChangeTransactionStatus(Guid id, string status, string buyerId){
        // }


    }
}
