using Microsoft.Extensions.Configuration;
using MKTFY.Models.Entities;
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
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly HttpClient _httpClient;

        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _httpClient = new HttpClient();
        }

        // Create the user if it's new or update it if it already exists
        // NOTE: Returns an error string or null for a success
        public async Task<string> CreateOrUpdate(string accessToken)
        {
            // Get the updated profile information
            var result = await ProfileRequest(accessToken);
            if (result == null)
                return "Unable to update the user profile";

            // Get the existing user
            var user = await _userRepository.GetById(result.sub);

            // Create or Update the user
            var userData = new User
            {
                Id = result.sub,
                FirstName = result.user_metadata?.firstName,
                LastName = result.user_metadata?.lastName,
                Email = result.email,
                Phone = result.user_metadata?.phone
            };
            if (user == null)
                await _userRepository.Create(userData);
            else
                await _userRepository.Update(userData);

            return null;
        }

        // Get the user's profile information from Auth0
        private async Task<UserInfoResponse> ProfileRequest(string accessToken)
        {
            var authUrl = _configuration.GetSection("Auth0").GetValue<string>("Domain");

            // Build the request
            var req = new HttpRequestMessage(HttpMethod.Get, authUrl + "/userInfo");
            req.Headers.Add("Authorization", "Bearer " + accessToken);
            var res = await _httpClient.SendAsync(req);

            if (!res.IsSuccessStatusCode)
                return null;

            var result = await res.Content.ReadFromJsonAsync<UserInfoResponse>();
            return result;
        }
    }

    public class UserInfoResponse
    {
        public string sub { get; set; }

        public string email { get; set; }

        [JsonPropertyName("http://schemas.mktfy.com/user_metadata")]
        public UserInfoResponseMeta user_metadata { get; set; }
    }

    public class UserInfoResponseMeta
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string phone { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string address { get; set; }
    }
}
