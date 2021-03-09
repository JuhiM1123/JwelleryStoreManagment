using JwelleryStore.Business.Encrption;
using JwelleryStore.Business.JWT;
using JwelleryStore.Common.DTO;
using JwelleryStore.Common.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Security.Claims;
using System.Threading.Tasks;


namespace JwelleryStore.UnitTest
{
    [TestClass]
    public class LoginInformationUnitTests
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
        public async Task LoginWithInvalidCredentials()
        {
            var encryptionManager = _serviceProvider.GetService<IEncryptionManager>();
            var requestBody = new AuthenticationModel
            {
                Username = "admin",
                Password = encryptionManager.EncryptAESPassword("invalidPassword")
            };

            var response = await _client.PostAsync("/api/Account/login", ContentHelper.GetStringContent(requestBody));
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task LoginWithValidCredentials()
        {
            var encryptionManager = _serviceProvider.GetService<IEncryptionManager>();
            var requestBody = new AuthenticationModel
            {
                Username = "normalUser",
                Password = encryptionManager.EncryptAESPassword("nu")
            };
            var response = await _client.PostAsync("/api/Account/login", ContentHelper.GetStringContent(requestBody));
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var loginResponseContent = await response.Content.ReadAsStringAsync();
            var loginResult = JsonSerializer.Deserialize<UserDetailDTO>(loginResponseContent);

            Assert.IsNotNull(loginResult.UserName);
            Assert.AreEqual("Normal", loginResult.RoleName);
            Assert.IsFalse(string.IsNullOrWhiteSpace(loginResult.Token));

            var jwtAuthManager = _serviceProvider.GetService<IJWTTokenManager>();
            var (principal, jwtSecurityToken) = jwtAuthManager.DecodeJwtToken(loginResult.Token);
            Assert.AreEqual(requestBody.Username, principal.Identity.Name);
            Assert.AreEqual("Normal", principal.FindFirst(ClaimTypes.Role).Value);
            Assert.IsNotNull(jwtSecurityToken);
        }

    }
}
