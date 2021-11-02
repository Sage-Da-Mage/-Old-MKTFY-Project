using Microsoft.EntityFrameworkCore;
using MKTFY.Models.Entities;
using MKTFY.Repositories.Repositories.Interfaces;
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

        // Create a new listing
        public async Task<Listing> Create(Listing src)
        {
            // Add and save changes made to the database
            src.Created = DateTime.UtcNow;
            _context.Listings.Add(src);                     // Preform the add in the memory
            await _context.SaveChangesAsync();              // Save the changes to the database

            // Return the new Listing, new Id will by added by Entity Framework automatically
            return src;
        }

        // Get a single listing by Id
        public async Task<Listing> Get(Guid id)
        {

            // Get the Listing Entity you are seeking
            var result = await _context.Listings.FirstAsync(i => i.Id == id);

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
            var result = await _context.Listings.FirstAsync(i => i.Id == src.Id) ;

            // Preform the update on the Listing entity
            result.Title = src.Title;
            result.Description = src.Description;
            result.Address = src.Address;
            result.Price = src.Price;

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
    }
}
