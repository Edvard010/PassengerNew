using Newtonsoft.Json;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task Given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            user.Email.Equals(email);
        }

        [Fact]
        public async Task Given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@email.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.Equals(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@email.com",
                Username = "test",
                Password = "secret"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            response.StatusCode.Equals(HttpStatusCode.Created);
            response.Headers.Location.ToString().Equals($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.Equals(command.Email);
        }

        private async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
