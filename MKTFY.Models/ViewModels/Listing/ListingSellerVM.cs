using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// The View Model Class used for the seller of a Listing.
    /// </summary>
    public class ListingSellerVM
    {
        /// <summary>
        /// The constructor for generating a ListingSellerVM from a Listing
        /// </summary>
        /// <param name="src"></param>
        public ListingSellerVM(Entities.Listing src)
        {
            Id = src.Id;
            ProductName = src.ProductName;
            SellerName = src.User.FullName;
            SellerAddress = src.User.UserAddress;
        }

        /// <summary>
        /// The Id of the user selling the Listing.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product being sold.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The name of the user selling the listing.
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// The address of the user selling the listing.
        /// </summary>
        public string SellerAddress { get; set; }


    }
}