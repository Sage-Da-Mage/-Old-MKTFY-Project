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
    public class SearchRepository : ISearchRepository
    {

        private readonly ApplicationDbContext _context;

        public SearchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Save(SearchItem search)
        {

            _context.SearchItems.Add(search);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SearchItem>> GetPriorSearches(string userId)
        {
            var results = await _context.SearchItems
               .Where(x => x.UserId == userId)
               .OrderByDescending(x => x.DateCreated)
               .Take(3)
               .ToListAsync();
            return results;
        }
    }
}
