using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// This is a View Model for showing all listings or creating a new listing
    /// </summary>
    public class ListingVM
    {
        /// <summary>
        /// The default constructor for the creation of an empty ListingVM
        /// </summary>
        public ListingVM()
        {

        }

        /// <summary>
        /// The Constructor for populating a new ListingVM from a Listing Entity
        /// </summary>
        /// <param name="src"></param>
        public ListingVM(Entities.Listing src)
        {
            Id = src.Id;
            CategoryId = src.CategoryId;
            Price = src.Price;
            ProductName = src.ProductName;
            Description = src.Description;
            Condition = src.Condition;
            Address = src.Address;
            City = src.City;
            UserId = src.UserId;
            StatusOfTransaction = src.StatusOfTransaction;
            DateSold = src.DateSold;

        }

    // Below are the objects that a Listing/ListingVM possesses/needs

        /// <summary>
        /// The Id is the guid that is used to identify different listings in searches.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The Category Id is a number that represents the type of product the Listing is,
        /// it is a number because it is better practice for changes/modifications. 
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The date that the Listing was created (This is never changed/modified)
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The name of the product being Listed.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// A brief description/summary of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The condition of the product (should be 1 of a couple options only)
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// The address for pickup of the Listing
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The city which the Listing is
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// The time that the product is sold, null until this is true.
        /// </summary>
        public DateTime? DateSold { get; set; }

        /// <summary>
        /// The status of the transaction (Listing, Sold etc.)
        /// </summary>
        public string StatusOfTransaction { get; set; }

        /// <summary>
        /// The User Id of the person placing the listing.
        /// </summary>
        public string UserId { get; set; }
    }
}
