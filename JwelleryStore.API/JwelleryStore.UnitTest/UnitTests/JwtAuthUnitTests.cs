using JwelleryStore.Business.Encrption;
using JwelleryStore.Business.JWT;
using JwelleryStore.Common.DTO;
using JwelleryStore.Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace JwelleryStore.UnitTest
{
    [TestClass]
    public class JwtAuthUnitTests
    {
        private readonly TestHost _testHost = new TestHost();
        private HttpClient _client;
        private DependencyResolverHelper _serviceProvider;

        [TestInitialize]
        public void SetUp()
        {
            _client = _testHost.Client;
            _serviceProvider = new DependencyResolverHelper(_testHost._WebHost);
        }

        [TestMethod]
        public async Task ValidateToken()
        {
            var encryptionManager = _serviceProvider.GetService<IEncryptionManager>();
            var requestBody = new AuthenticationModel
            {
                Username = "privilegedUser",
                Password = encryptionManager.EncryptAESPassword("pu")
            };
            var response = await _client.PostAsync("/api/Account/login", ContentHelper.GetStringContent(requestBody));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var loginResponseContent = await response.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<UserDetailDTO>(loginResponseContent);

            var jwtAuthManager = _serviceProvider.GetService<IJWTTokenManager>();
            var (principal, jwtSecurityToken) = jwtAuthManager.DecodeJwtToken(loginResult.Token);
            Assert.IsNotNull(jwtSecurityToken);
            Assert.AreEqual(loginResult.Token, jwtSecurityToken.RawData);
            Assert.AreEqual(requestBody.Username, principal.Identity.Name);
            Assert.AreEqual("Privileged", principal.FindFirst(ClaimTypes.Role).Value);

        }

        [TestMethod]
        public async Task UnauthrorisedAccess()
        {
            var encryptionManager = _serviceProvider.GetService<IEncryptionManager>();
            var requestBody = new AuthenticationModel
            {
                Username = "privilegedUser",
                Password = encryptionManager.EncryptAESPassword("pu")
            };
            var response = await _client.PostAsync("/api/Account/login", ContentHelper.GetStringContent(requestBody));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var loginResponseContent = await response.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<UserDetailDTO>(loginResponseContent);

            var jwtAuthManager = _serviceProvider.GetService<IJWTTokenManager>();
            var (principal, jwtSecurityToken) = jwtAuthManager.DecodeJwtToken(loginResult.Token);
            Assert.IsNotNull(jwtSecurityToken);
            Assert.AreEqual(loginResult.Token, jwtSecurityToken.RawData);
            Assert.AreEqual(requestBody.Username, principal.Identity.Name);
            Assert.AreEqual("Privileged", principal.FindFirst(ClaimTypes.Role).Value);

            var getUserResponse = await _client.GetAsync("api/weatherforecast");
            Assert.AreEqual(HttpStatusCode.Unauthorized, getUserResponse.StatusCode);

        }

        [TestMethod]
        public async Task AuthorisedAcessWithToken()
        {
            var encryptionManager = _serviceProvider.GetService<IEncryptionManager>();
            var requestBody = new AuthenticationModel
            {
                Username = "privilegedUser",
                Password = encryptionManager.EncryptAESPassword("pu")
            };
            var response = await _client.PostAsync("/api/Account/login", ContentHelper.GetStringContent(requestBody));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var loginResponseContent = await response.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<UserDetailDTO>(loginResponseContent);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, loginResult.Token);
            var weatherForecastContent = await _client.GetAsync("api/weatherforecast");

            Assert.AreEqual(HttpStatusCode.OK, weatherForecastContent.StatusCode);

        }

    }
}
