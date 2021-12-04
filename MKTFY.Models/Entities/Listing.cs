using MKTFY.Models.ViewModels.Listing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    /// <summary>
    /// The Listing entity used throughout the MKTFY project.
    /// </summary>
    public class Listing
    {
        /// <summary>
        /// Default constructor so we can create an empty Listing Entity if needed
        /// </summary>
        public Listing()
        {
        }

        /// <summary>
        /// Constructor we use to create a new Listing from a ListingAddVM model
        /// </summary>
        /// <param name="src"></param>
        /// <param name="userId"></param>
        public Listing(ListingAddVM src, string userId)
        {
            CategoryId = src.CategoryId;
            Price = src.Price;
            ProductName = src.ProductName;
            Description = src.Description;
            Condition = src.Condition;
            Address = src.Address;
            City = src.City;
            UserId = userId;

        }

        /// <summary>
        ///  A Constructor we use to update an existing Listing from a ListingUpdateVM model
        /// </summary>
        /// <param name="src"></param>
        public Listing(ListingUpdateVM src)
        {
            Id = src.Id;
            CategoryId = src.CategoryId;
            Price = src.Price;
            ProductName = src.ProductName;
            Description = src.Description;
            Condition = src.Condition;
            Address = src.Address;
            City = src.City;
        }


        /// <summary>
        /// The Guid Id used to differenciate/identify desired Listings.
        /// </summary>
        [Key]
        public Guid Id { get; set; }


        /// <summary>
        /// An int for identifying the category, current list in ListingAddVM.cs
        /// </summary>
        [Required]
        public int CategoryId { get; set; }
        
        // DETERMINE IF I NEED TO ADD A CATEGORY CLASS TO THE PROJECT
        //public Category Category { get; set; }

        /// <summary>
        /// The price of the Listing.
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// The Date and time that the Listing was created. NEVER CHANGED
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        [Required]
        public string ProductName { get; set; }

        /// <summary>
        /// A short description of the product.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The condition of the product. (1 of a couple options only)
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// The address where the Listing is posted from.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city the posting is set in.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// The time and date the Listing was sold, null initially but once assigned NEVER CHANGED.
        /// </summary>
        public DateTime? DateSold { get; set; }
        
        /// <summary>
        /// The Id of the user buying the listing.
        /// </summary>
        public string BuyerId { get; set; }
        
        /// <summary>
        /// The Status of the transaction, starts as Listing, but changes based on events.
        /// </summary>
        [Required]
        public string StatusOfTransaction { get; set; }


        /// <summary>
        /// The user who created the listing
        /// </summary>
        [Required]
        public string UserId { get; set; }
        
        /// <summary>
        /// The User Class of the User who posted the Listing.
        /// </summary>
        public User User { get; set; }




    }
}
