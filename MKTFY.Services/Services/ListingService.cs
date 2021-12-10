using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels;
using MKTFY.Models.ViewModels.Listing;
using MKTFY.Repositories.Repositories;
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
        private readonly ISearchRepository _searchRepository;
        private readonly IUploadRepository _uploadRepository;

        public ListingService(IListingRepository listingRepository, ISearchRepository searchRepository, IUploadRepository uploadRepository)
        {
            _listingRepository = listingRepository;
            _searchRepository = searchRepository;
            _uploadRepository = uploadRepository;
        }

        public async Task<ListingVM> Create(ListingAddVM src, string userId)
        {
            //Create the new Listing entity
            var newEntity = new Listing(src, userId);

            // Add a default StatusOfTransaction and set DateSold to null
            newEntity.StatusOfTransaction = "Listed";
            newEntity.DateSold = null;

            // Have the repository create the new listing
            var result = await _listingRepository.Create(newEntity);

            // Create the ListingVM we want to return to the client
            var model = new ListingVM(result);


            // Remember to get the url collection


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

        public async Task<List<ListingVM>> GetByCategory(int categoryId, string region)
        {
            var results = await _listingRepository.GetByCategory(categoryId, region);
            var models = results.Select(listing => new ListingVM(listing)).ToList();
            return models;
        }

        /*public async Task<List<ListingVM>> GetDeals(string userId, string region)
        {
            //retrieve user's last 3 search terms
            var searchHistory = await _searchRepository.GetLatestSearches(userId);

            //find listings matching search terms
            var dealListings = new List<Listing>();
            foreach (SearchHistory search in searchHistory)
            {
                var dealResults = await _listingRepository.GetBySearchTerm(search.SearchTerm, region);
                dealListings.AddRange(dealResults);
            }
            var distinctListings = dealListings.Distinct();
            var models = distinctListings.Select(listing => new ListingVM(listing)).ToList();
            return models;
        }*/

        public async Task<List<ListingVM>> GetBySearchTerm(SearchCreateVM src, string region)
        {
            //save search term to SearchItem Table
            var newSearchEntity = new SearchItem(src);
            newSearchEntity.DateCreated = DateTime.UtcNow;
            await _searchRepository.Save(newSearchEntity);

            //get search
            var results = await _listingRepository.GetBySearchTerm(src.SearchTerm, region);
            var models = results.Select(listing => new ListingVM(listing)).ToList();
            return models;
        }


        public async Task<ListingSellerVM> GetPickupInfo(Guid id)
        {

            var result = await _listingRepository.GetPickupInfo(id);

            var model = new ListingSellerVM(result);

            return model;

        }

        public async Task ChangeTransactionStatus(Guid id, string status, string buyerId)
        {


            await _listingRepository.ChangeTransactionStatus(id, status, buyerId);
        }

        /*private async Task<ListingVM> AddUploadDetails(Listing result)
        {
            var model = new ListingVM(result);
            //get the Upload Id
            var uploadIds = result.ListingUploads.Select(i => i.UploadId).ToList();
            //get the Upload Url
            foreach (Guid uploadId in uploadIds)
            {
                var upload = await UploadRepository.Get(uploadId);
                //model.UploadUrls.Add(upload.Url);
            }
            //model.UploadIds = uploadIds;

            return model;
        }*/


    }
}
