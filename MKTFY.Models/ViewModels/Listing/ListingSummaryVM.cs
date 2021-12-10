﻿using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    /// <summary>
    /// The ListingSummaryVM class for providing a brief overview of a Listing
    /// </summary>
    public class ListingSummaryVM
    {

        /// <summary>
        /// The empty constructor for ListingSummaryVM
        /// </summary>
        public ListingSummaryVM() { }

        /// <summary>
        /// The Constructor that takes in a Listing
        /// </summary>
        /// <param name="src"></param>
        public ListingSummaryVM(Entities.Listing src)
        {
            Id = src.Id;
            ProductName = src.ProductName;
            Price = src.Price;
            ImageUrl = src.ListingUploads.Select(id => id.Upload.Url).First();
            StatusOfTransaction = src.StatusOfTransaction;
        }

        /// <summary>
        /// The Id of the listing
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The amount that it costs to purchase the listing
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The url for images related to the Listing
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// The status of the Listing, in regard to getting sold
        /// </summary>
        public string StatusOfTransaction { get; set; }

    }
}
