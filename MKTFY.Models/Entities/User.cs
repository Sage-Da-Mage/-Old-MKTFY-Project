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
    /// <summary>
    /// The Entity for Users and their properties.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The base constructor class for user.
        /// </summary>
        public User() { }

        /// <summary>
        /// Create a User from an inputted source of data.
        /// </summary>
        /// <param name="src"></param>
        public User(UserAddVM src)
        {  
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;
            UserAddress = src.UserAddress;
            City = src.City;
            Province = src.Province;
            Country = src.Country;
            Email = src.Email;

        }

        /// <summary>
        /// Create A user from a UserUpdateVM
        /// </summary>
        /// <param name="src"></param>
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

        /// <summary>
        /// The Id of the User (used to diferenciate or identify users).
        /// </summary>
        [Required]
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The First name of the User.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the User.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The Users email. (CHECK FOR REQUIREMENTS)
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// The phone # of the user. (10 digit string of numbers)
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// The adress of the user.
        /// </summary>
        [Required]
        public string UserAddress { get; set; }

        /// <summary>
        /// The city the user resides in.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// The province the user resides in.
        /// </summary>
        [Required]
        public string Province { get; set; }

        /// <summary>
        /// The country the user resides in.
        /// </summary>
        [Required]
        public string Country { get; set; }


        /// <summary>
        /// The DateTime that this user was generated.
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Generate a Full name from the first and last names.
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Generate a full address from the users Address, City, Province and Country.
        /// </summary>
        [NotMapped]
        public string FullAddress
        {
            get
            {
                return ($"{UserAddress}, {City}, {Province}, {Country}");
            }
        }

        /// <summary>
        /// Listings User Created.
        /// </summary>
        public ICollection<Listing> Listings { get; set; }
    }
}
