using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Repositories.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly ApplicationDbContext _context;

        public ListingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // UPDATE THE BELOW METHODS TO A BETTER STANDARD + UPLOADING IMAGES


        // Create a new listing
        public async Task<Listing> Create(Listing src)
        {
            // Add and save changes made to the database
            src.DateCreated = DateTime.UtcNow;

            _context.Listings.Add(src);                     // Preform the add in the memory
            await _context.SaveChangesAsync();              // Save the changes to the database

            // Return the new Listing, new Id will by added by Entity Framework automatically
            return src;
        }

        // Get a single listing by Id
        public async Task<Listing> Get(Guid id)
        {

            // Get the Listing Entity you are seeking
            var result = await _context.Listings.Include(listing => listing.User).FirstOrDefaultAsync(i => i.Id == id);
            if (result == null)
                throw new NotFoundException("The requested listing could not be found");

            // return the retrieved entry
            return result;

        }

        // Get all of the listings in the database
        public async Task<List<Listing>> GetAll()
        {
            // Get all of the Listing Entities
            var results = await _context.Listings.ToListAsync();

            //Return the Listing Entities retrieved from the above line
            return results;
        }

        // Update a currently existing Listing
        public async Task<Listing> Update(Listing src)
        {

            // Get the entity to update
            var result = await _context.Listings
                .Include(u => u.ListingUploads).ThenInclude(u => u.Upload)
                .FirstOrDefaultAsync(i => i.Id == src.Id) ;
                    
            // If there is no matching Listing then return an exception
            if (result == null)
                throw new NotFoundException("The requested listing could not be found");


            // Compare the old and new UploadIds to confirm changes
            // - REMEMBER TO MAKE AN EXCEPTION FOR A NULL IMAGE
            var listofResultUploadIds = result.ListingUploads.Select(u => u.UploadId).ToList();
            var listofSrcUploadIds = src.ListingUploads.Select(u => u.UploadId).ToList();
            
            var resultNotSrc = listofResultUploadIds.Except(listofSrcUploadIds).ToList();
            var srcNotResult = listofSrcUploadIds.Except(listofResultUploadIds).ToList();


            // Delete the uploads that need deleting based on the above check
            foreach (var upload in result.ListingUploads)
            {
                if (resultNotSrc.Contains(upload.UploadId))
                {
                    //remove the selected upload from listing and listingUpload 
                    result.ListingUploads.Remove(upload);
                    //remove the image from Uploads
                    _context.Uploads.Remove(upload.Upload);
                }
            }

            //add any new images to listingUploads
            foreach (var uploadId in srcNotResult)
            {
                var listingUpload = src.ListingUploads.First(i => i.UploadId == uploadId);

                //add to the listing 
                result.ListingUploads.Add(listingUpload);
            }


            // Preform the update on the Listing entity
            result.CategoryId = src.CategoryId;
            result.Price = src.Price;
            result.ProductName = src.ProductName;
            result.Description = src.Description;
            result.Condition = src.Condition;
            result.Address = src.Address;
            result.City = src.City;
            //result.UploadId = src.UploadId;

            // Save the updates to the database
            await _context.SaveChangesAsync();

            // Return the Actual entity class and not the src class so that we are sure that the database Listing is correct
            return result;
        }

        // Delete a specific Listing
        public async Task Delete(Guid id)
        {
            // Get the specific Listing Entity you wish to delete
            var result = await _context.Listings.FirstAsync(i => i.Id == id);

            //Remove the entity from the collection in your memory
            _context.Remove(result);

            // Remove the entity from the database
            await _context.SaveChangesAsync();
        } 


        public async Task<List<Listing>> GetByCategory(int categoryId, string region)
        {
            var results = await _context.Listings
                .Where(listing => listing.CategoryId == categoryId &&
                    listing.City == region &&
                    listing.StatusOfTransaction == "Listed")
                .Include(e => e.ListingUploads).ThenInclude(e => e.UploadId)
                .ToListAsync();
            return results;
        }

        // 

        public async Task<List<Listing>> GetBySearchTerm(string searchTermLowerCase, string city)
        {
            var results = await _context.Listings
                .Where(listing => listing.City == city                                
                    && listing.StatusOfTransaction == "listed" &&                       //
                   (listing.Description.ToLower().Contains(searchTermLowerCase) ||      // or
                    listing.ProductName.ToLower().Contains(searchTermLowerCase) ||      // or
                    (listing.Category.Name.ToLower().Contains(searchTermLowerCase))))
                .Include(e => e.ListingUploads).ThenInclude(e => e.UploadId)
                .ToListAsync();
            return results;
        }

        // Get the pickup information for a purchase
        public async Task<Listing> GetPickupInfo(Guid id)
        {
            var result = await _context.Listings
                .Include(listing => listing.User)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (result == null) throw new NotFoundException("The requested listing could not be found");
            return result;

        }

        /*public async Task<List<Listing>> GetMyPurchases(string buyerId)
        {


        }

        public async Task<List<Listing>> GetMyListings(string userId, string status)
        {
  

        }*/

        public async Task ChangeTransactionStatus(Guid id, string status, string buyerId)
        {
            // Get the listing requested and throw an exception if you can't find it.
            var result = await _context.Listings
                .Include(e => e.User)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (result == null) throw new NotFoundException("The requested listing could not be found");

            // If the status has been Canceled, convert it to Listed and empty the BuyerId property
            if (status == "Cancelled")
            {
                result.BuyerId = "";
                status = "Listed";
            }

            // Remember check for incorrect status changes we should be unable to change the status of sold items
            result.StatusOfTransaction = status;

            // A listing that hasn't been purchased yet needs a buyer in addition to the seller
            if (status == "Pending")
            {
                result.BuyerId = buyerId;
            }

            // A listing that has been sold needs to have the DateTime added to the DateSold property
            if (status == "Sold")
            {
                result.DateSold = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

    }
}
