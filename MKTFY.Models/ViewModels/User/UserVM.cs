using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{
    /// <summary>
    /// The UserVm class is for generating a View Model of the User Class.
    /// It can be built from a User class.
    /// </summary>
    public class UserVM
    {
        /// <summary>
        /// The src User passes all the information it can into the View Model
        /// </summary>
        /// <param name="src"></param>
        public UserVM(Entities.User src)
        {
            Id = src.Id;
            FirstName = src.FirstName;
            LastName = src.LastName;            
            Email = src.Email;
            Phone = src.Phone;
            UserAddress = src.UserAddress;
            City = src.City;
            Province = src.Province;
            Country = src.Country;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Country { get; set; }
    }
}
