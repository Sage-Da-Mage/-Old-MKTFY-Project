using MKTFY.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.Entities
{
    public class User
    {
        public User() { }

        public User(UserAddVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;
            UserAddress = src.UserAddress;
            City = src.City;
            Province = src.Province;
            Country = src.Country;
            Email = src.Email;

        }

        public User(UserUpdateVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;
            UserAddress = src.UserAddress;
            City = src.City;
            Province = src.Province;
            Country = src.Country;
        }

        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string UserAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Country { get; set; }


        // Check if I need a datecreated for a user
        [Required]
        public DateTime DateCreated { get; set; }

        // Generate a full name from the first and last name
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [NotMapped]
        public string FullAddress
        {
            get
            {
                return ($"{UserAddress}, {City}, {Province}, {Country}");
            }
        }

        // Listings user created
        public ICollection<Listing> Listings { get; set; }
    }
}
