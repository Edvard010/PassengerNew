using Newtonsoft.Json;
using Passenger.Core.Domain;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {

        [Fact]
        public async Task Given_valid_email_user_should_exist()
        {
            string email = "user1@email.com";
            HttpResponseMessage response = await Client.GetAsync($"users/{email}");
            //response.EnsureSuccessStatusCode();
            string responseString = await response.Content.ReadAsStringAsync();
            UserDto user = JsonConvert.DeserializeObject<UserDto>(responseString);
            //Assert
            Assert.Equal(email, user.Email);
        }

        [Fact]
        public async Task Given_invalid_email_user_should_not_exist()
        {
            var email = "user1000@email.com";
            HttpResponseMessage response = await Client.GetAsync($"users/{email}");
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
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal($"users/{command.Email}", response.Headers.Location.ToString());

            var user = await GetAsync(command.Email);
            Assert.Equal(command.Email, user.Email);
        }


        private async Task<UserDto> GetAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
