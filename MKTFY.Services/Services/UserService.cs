using Microsoft.Extensions.Configuration;
using MKTFY.Models.Entities;
using MKTFY.Models.ViewModels.User;
using MKTFY.Repositories.Repositories.Interfaces;
using MKTFY.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MKTFY.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserVM> Create(UserAddVM src, string userId)
        {
            // Create the new user entity
            var newEntity = new User(src);

            newEntity.Id = userId;

            // Have the repository create the new user
            var result = await _userRepository.Create(newEntity);



            // Create the UserVM we want to return to the client
            var model = new UserVM(result);

            // Return a UserVM
            return model;
        }

        public async Task<UserVM> Get(string id)
        {
            // Get the requested User entity from the repository
            var result = await _userRepository.GetById(id);

            // Create the UserVM we want to return to the client
            var model = new UserVM(result);

            // Return the UserVM
            return model;
        }

        public async Task<UserVM> Update(UserUpdateVM src)
        {
            // Have the repository update the user
            var updateData = new User(src);
            var result = await _userRepository.Update(updateData);

            // Create the UserVM we want to return to the client
            var model = new UserVM(result);

            // Return a 200 response with the UserVM
            return model;
        }
    }
}
