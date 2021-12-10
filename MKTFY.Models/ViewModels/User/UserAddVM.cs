using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{
    /// <summary>
    /// The UserAddVM class allows us to create a UserVM.
    /// </summary>
    public class UserAddVM
    {

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
        public string Email { get; set; }

        /// <summary>
        /// Should be in the format of a 10 digit set of numbers
        /// </summary>
        [Required]
        [MinLength(10, ErrorMessage = "The property {0} should have a minimum of {1} digit")]
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
