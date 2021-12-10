using MKTFY.Models.ViewModels.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// This VM displays the Listing and how many Listings that user has.
    /// </summary>
    public class ListingsPlusSellerVM
    {
        /// <summary>
        /// The empty constructor for ListingPlusSellerVM
        /// </summary>
        public ListingsPlusSellerVM() 
        { 

        }

        /// <summary>
        /// The constructor that takes in a Listing and the count of Listings the User has.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="sellersListingCount"></param>
        public ListingsPlusSellerVM(Entities.Listing src, int sellersListingCount)
        {
            Id = src.Id;
            ProductName = src.ProductName;
            Description = src.Description;
            Price = src.Price;
            CategoryId = src.CategoryId;
            SellerId = src.UserId;
            Condition = src.Condition;
            City = src.City;
            SellerFullName = src.User.FullName;

            // Iterate for all relevant images and include them
            Images = src.ListingUploads.Select(id => new UploadVM { Id = id.Upload.Id, Url = id.Upload.Url }).ToList();

            SellersTotalListings = sellersListingCount;
        }

        /// <summary>
        /// The Id of the Listing
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product in the Listing
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// A short description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The amount it will cost to purchase the Listing
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// A number which represents a category type that changes searches
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// The condition of the product
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// The city the user is in
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Images of the product
        /// </summary>
        public List<UploadVM> Images { get; set; }

        /// <summary>
        /// The Id of the seller
        /// </summary>
        public string SellerId { get; set; }

        /// <summary>
        /// The Sellers full name
        /// </summary>
        public string SellerFullName { get; set; }

        /// <summary>
        /// The number of Listings that the Seller has put out
        /// </summary>
        public int SellersTotalListings { get; set; }

    }
}
