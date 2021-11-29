using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    // The difference between this and ListingAddVM file is that
    // it must contain any/only objects that can be updated. (i.e. no Created variable)
    public class ListingUpdateVM
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        // May want to add a check for if it is a proper categoryId in future (not a number unassigned to an id)
        public int CategoryId { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Condition { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

    }
}
