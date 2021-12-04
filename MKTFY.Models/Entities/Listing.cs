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

    //  Our normal properties, all are required and the Id is a key
        [Key]
        public Guid Id { get; set; }


        // An int for identifying the category, current list in ListingAddVM.cs
        [Required]
        public int CategoryId { get; set; }
        
        // DETERMINE IF I NEED TO ADD A CATEGORY CLASS TO THE PROJECT
        //public Category Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        public string Condition { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        public DateTime? DateSold { get; set; }
        
        public string BuyerId { get; set; }
        
        [Required]
        public string StatusOfTransaction { get; set; }


        // The user who created the listing
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }




    }
}
