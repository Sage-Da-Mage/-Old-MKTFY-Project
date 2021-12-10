using MKTFY.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// The entity that represents a search done on the site
    /// </summary>
    public class SearchItem
    {
        /// <summary>
        /// The empty SearchItem constructor
        /// </summary>
        public SearchItem() { }
        
        /// <summary>
        /// The SearchItem constructor that takes in a SearchCreateVM
        /// </summary>
        /// <param name="src"></param>
        public SearchItem(SearchCreateVM src)
        {
            SearchTerm = src.SearchTerm;
            UserId = src.UserId;
        }

        /// The Id of the search
        [Key]
        public Guid Id { get; set; }

        /// The term that was searched
        [Required]
        public string SearchTerm { get; set; }

        /// The DateTime of the time the search was done
        [Required]
        public DateTime DateCreated { get; set; }

        /// This is the Id of the user making the search
        [Required]
        public string UserId { get; set; }
        
        ///User User allows us to access the User details
        public User User { get; set; }

    }
}
