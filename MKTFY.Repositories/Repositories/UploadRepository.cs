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
    public class UploadRepository : IUploadRepository
    {
        private readonly ApplicationDbContext _context;

        public UploadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // UPDATE THE BELOW METHODS TO A BETTER STANDARD + UPLOADING IMAGES


        // Create a new listing
        public async Task<Upload> Create(Upload src)
        {
            // Add and save changes made to the database
            _context.Uploads.Add(src);                     // Preform the add in the memory
            await _context.SaveChangesAsync();              // Save the changes to the database

            // Return the new Listing, new Id will by added by Entity Framework automatically
            return src;
        }

        // Get a single listing by Id
        public async Task<Upload> Get(Guid id)
        {

            // Get the Upload Entity you are seeking
            var result = await _context.Uploads.FirstOrDefaultAsync(i => i.Id == id);
            if (result == null)
                throw new NotFoundException("The requested upload could not be found");

            // return the retrieved entry
            return result;

        }

        // Delete a specific Upload
        public async Task Delete(Guid id)
        {
            // Get the specific Upload Entity you wish to delete
            var result = await _context.Uploads.FirstAsync(i => i.Id == id);

            //Remove the entity from the collection in your memory
            _context.Remove(result);

            // Remove the entity from the database
            await _context.SaveChangesAsync();

        }
    }
}
