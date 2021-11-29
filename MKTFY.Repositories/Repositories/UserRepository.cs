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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        // UPDATE THE BELOW METHODS TO A BETTER LEVEL

        // Create a new listing
        public async Task<User> Create(User src)
        {
            // Add and save the changes to the database
            _context.Users.Add(src);            // Perform the add in memory
            await _context.SaveChangesAsync();  // Save the changes to the real database

            // Return the new user. Entity Framework will have automatically added the new Id value to the entity class.
            return src;
        }

        // Get a single user by Id
        // Note: Will return null if user doesn't exist
        public async Task<User> GetById(string id)
        {
            // Get the entity (it's okay if it doesn't exist)
            var result = await _context.Users.FirstOrDefaultAsync(i => i.Id == id);

            // Return the retrieved entity
            return result;
        }

        // Update an existing user
        public async Task<User> Update(User src)
        {
            // Get the entity
            var user = await _context.Users.FirstAsync(i => i.Id == src.Id);

            // Perform the updates on the entity -- (but not datecreated or email, those are the same)
            user.FirstName = src.FirstName;
            user.LastName = src.LastName;
            user.Phone = src.Phone;
            user.City = src.City;
            user.Province = src.Province;
            user.Country = src.Country;

            // Save the updates to the real database
            await _context.SaveChangesAsync();

            // Return the actual entity class and not the src class so you're guaranteed that the value
            // returned matches what's in the database, not just want "should" be in the database.
            return user;
        }


    }
}
