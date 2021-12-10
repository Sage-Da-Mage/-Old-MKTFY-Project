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
    public class FAQRepository : IFAQRepository
    {
        private readonly ApplicationDbContext _context;

        public FAQRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create an FAQ from inputted data (src)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public async Task<FAQ> Create(FAQ src)
        {
            // Determine the current time (when the FAQ was made)
            src.DateCreated = DateTime.UtcNow;
            _context.FAQ.Add(src);
            await _context.SaveChangesAsync();
            return src;
        }

        /// <summary>
        /// Get a specific FAQ from an inputted id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FAQ> Get(Guid id)
        {
            // Get the FAQ Entity you want.
            var result = await _context.FAQ.FirstOrDefaultAsync(i => i.Id == id);

            //Throw an exception if you don't find the FAQ.
            if (result == null) 
                throw new NotFoundException("The requested listing could not be found");

            // Return the resulting FAQ (should have it if it passes the throw)
            return result;
        }

        /// <summary>
        /// Get all FAQs in the database/context.
        /// </summary>
        /// <returns></returns>
        public async Task<List<FAQ>> GetAll()
        {
            // Get all of the FAQ entities.
            var result = await _context.FAQ.ToListAsync();

            // Return the FAQ entities gathered in the line above.
            return result;
        }

        /// <summary>
        /// Update an FAQ that is passed in.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public async Task<FAQ> Update(FAQ src)
        {
            // Get the entity to update.
            var result = await _context.FAQ.FirstOrDefaultAsync(i => i.Id == src.Id);
            
            // If there is no FAQ entity found with the same id as passed in throw an exception.
            if (result == null) 
                throw new NotFoundException("The requested FAQ could not be found");
           
            // Preform the update upon the FAQ (not Id, that doesn't change)
            result.Question = src.Question;
            result.Answer = src.Answer;

            // Save the changes to the database.
            await _context.SaveChangesAsync();

            // Return the resulting FAQ
            return result;
        }
    }
}
