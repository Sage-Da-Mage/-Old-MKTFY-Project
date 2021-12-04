using MKTFY.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserVM> Create(UserAddVM src, string userId);     // Create a new User
        Task<UserVM> Get(string id);            // Get a single existing user by Id
        Task<UserVM> Update(UserUpdateVM src);  // Update an existing user
        
        // We don't need delete since we won't be deleting users (yet at least)


    }

}
