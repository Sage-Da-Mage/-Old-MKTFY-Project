using MKTFY.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{
    // This is a View Model for showing all listings or creating a new listing
    // A summary of the Listing
    public class ListingVM
    {
        // The default constructor for the creation of an empty ListingVM
        public ListingVM()
        {

        }

        // The Constructor for populating a new ListingVM from a Listing Entity
        public ListingVM(Entities.Listing src)
        {
            Id = src.Id;
            Title = src.Title;
            Description = src.Description;
            Price = src.Price;
            Address = src.Address;
            Created = src.Created;
            UserId = src.UserId;
            UserName = src.User?.FullName;

        }

    // Below are the objects that a Listing/ListingVM possesses/needs
    //{
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Address { get; set; }

        public DateTime Created { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    //}
    }
}
