using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    public class Listing
    {
        // Default constructor so we can create an empty Listing Entity if needed
        public Listing()
        {
        }

        // Constructor we use to create a new Listing from a ListingAddVM model
        public Listing(ListingAddVM src, string userId)
        {
            Title = src.Title;
            Description = src.Description;
            Price = src.Price;
            Address = src.Address;
            UserId = userId;

        }

        // A Constructor we use to update an existing Listing from a ListingUpdateVM model
        public Listing(ListingUpdateVM src)
        {
            Id = src.Id;
            Title = src.Title;
            Description = src.Description;
            Price = src.Price;
            Address = src.Address;

        }

    //  Our normal properties, all are required and the Id is a key
    //{ 
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

    //}


    }
}
