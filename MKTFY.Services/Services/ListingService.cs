using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public async Task<ListingVM> Create(ListingAddVM src, string userId)
        {
            //Create the new Listing entity
            var newEntity = new Listing(src, userId);

            // Add a default StatusOfTransaction
            newEntity.StatusOfTransaction = "Listed";

            // Have the repository create the new listing
            var result = await _listingRepository.Create(newEntity);

            // Create the ListingVM we want to return to the client
            var model = new ListingVM(result);

            // Return a ListingVM for client
            return model;
        }

        public async Task<ListingVM> Get(Guid id)
        {
            //Get the desired Listing Entity from the repository
            var result = await _listingRepository.Get(id);

            // Create the ListingVM that we want to return to the client
            var model = new ListingVM(result);

            // Return a 200 (ok/functioning correctly) response with the ListingVM to the client
            return model;
        }
        
        public async Task<List<ListingVM>> GetAll()
        {
            // Get the Listing entities from the repository
            var results = await _listingRepository.GetAll();

            // Build the ListingVM view models to return to the client
            var models = results.Select(listing => new ListingVM(listing)).ToList();

            // Return the ListingVms
            return models;
        }

        public async Task<ListingVM> Update(ListingUpdateVM src)
        {
            // Make the repository update the listing
            var updateData = new Listing(src);
            var result = await _listingRepository.Update(updateData);

            //Vreate the ListingVM model for returning to the client
            var model = new ListingVM(result);

            //Finally return the ListingVM to show that the change was sucessfull to the client
            return model;
        }

        public async Task Delete(Guid id)
        {
            // Inform the repository to delete the specified Listing Entity
            await _listingRepository.Delete(id);
        }
    }
}
