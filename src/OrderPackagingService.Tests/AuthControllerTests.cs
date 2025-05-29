using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using OrderPackagingService.Api.Controllers;
using Xunit;

namespace OrderPackagingService.Tests
{
    public class AuthControllerTests
    {
        private readonly AuthController _controller;
        private readonly Mock<IConfiguration> _configurationMock;

        public AuthControllerTests()
        {
            _configurationMock = new Mock<IConfiguration>();

            _configurationMock.Setup(c => c["Jwt:Issuer"]).Returns("http://localhost:8080");
            _configurationMock.Setup(c => c["Jwt:Audience"]).Returns("http://localhost:8080");
            _configurationMock.Setup(c => c["Jwt:SigningKey"]).Returns("YLcx8QnFWCYuT4UnqmLAMOpnA9hFR+J0Ol7exGCkz09QLxd/WVPxwNSXLQb4muiQyczeEWtX5B8oL7bualJKbg==");
            _configurationMock.Setup(c => c["Jwt:ExpirationInMinutes"]).Returns("120");

            _controller = new AuthController(_configurationMock.Object);
        }

        [Fact]
        public void GenerateToken_ReturnsValidToken()
        {
            var result = _controller.GenerateToken() as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var response = result.Value as Dictionary<string, object>;

            Assert.NotNull(response);
            Assert.True(response.ContainsKey("Token"));

            Assert.NotNull(response["Token"]);
            Assert.True(response.ContainsKey("ExpiresAt"));

            Assert.NotNull(response["ExpiresAt"]);
        }
    }
}