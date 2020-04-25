using IdentityModel.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Ninject.Activation;
using NUnit.Framework;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Tests.EndToEnd.Controllers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Passenger.Tests.EndToEnd
{
    public class AccountControllerTests : ControllerTestsBase
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public AccountControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }
        [Fact]
        public async Task Given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "secret",
                NewPassword = "secret2",
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            response.StatusCode.CompareTo(HttpStatusCode.NoContent);
        }
    }
}
