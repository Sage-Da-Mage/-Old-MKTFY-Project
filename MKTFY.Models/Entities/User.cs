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
            Email = src.Email;
            Phone = src.Phone;
        }

        public User(UserUpdateVM src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;
            Phone = src.Phone;
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

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // Listings user created
        public ICollection<Listing> Listings { get; set; }
    }
}
