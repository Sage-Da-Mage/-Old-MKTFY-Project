using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// This is the VM used during a purchase of a listing.
    /// </summary>
    public class ListingPurchaseVM
    {
        /// <summary>
        /// The empty constructor for ListingPurchaseVM
        /// </summary>
        public ListingPurchaseVM() { }

        /// <summary>
        /// The constructor that takes in a Listing.
        /// </summary>
        /// <param name="src"></param>
        public ListingPurchaseVM(Entities.Listing src)
        {
            Id = src.Id;
            ProductName = src.ProductName;
            Price = src.Price;
            DateSold = src.DateSold;
        }

        /// <summary>
        /// The Id of the Listing
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The amount that it would take to purchace the Listing
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The DateTime for when the Listing was purchased
        /// </summary>
        public DateTime? DateSold { get; set; }

    }
}
