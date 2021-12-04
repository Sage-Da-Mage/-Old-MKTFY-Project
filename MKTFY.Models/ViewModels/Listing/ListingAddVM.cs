using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Listing
{

    // This View Model is for adding a listing
    public class ListingAddVM
    {

        // Add swagger documentation later so frontend can see category id meanings later
        [Required]
        public int CategoryId { get; set; }
        // CategoryId: 1=Cars/Vehicles, 2=Furniture, 3=Electronics, 4=Real Estate
        // Potentially add more after talking with team

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        public string Condition { get; set; }

        public string Address { get; set; }

        public string City { get; set; }


    }
}
