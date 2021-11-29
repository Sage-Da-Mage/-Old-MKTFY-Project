using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.User
{
    public class UserVM
    {
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

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string UserAddress { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }
    }
}
