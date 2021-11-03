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
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
