using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{
    /// <summary>
    /// The UserUpdateVM class allows us to change the properties in User that are
    /// allowed to be changed.
    /// </summary>
    public class UserUpdateVM
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string UserAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Country { get; set; }
    }
}
