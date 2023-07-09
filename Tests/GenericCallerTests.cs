using Xunit;
using FluentAssertions;
using ApiBrasil;
using ApiBrasil.Domain;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Tests
{
    public class GenericCallerTests
    {
        [Fact]
        public async Task Call_ShouldReturnContent()
        {
            // Arrange
            var type = "exampleType";
            var action = "exampleAction";
            var content = new
            {
                message = "oi"
            };

            var config = new ApiBrasilConfiguration
            {
                SecretKey = "exampleSecretKey",
                PublicToken = "examplePublicToken",
                DeviceToken = "exampleDeviceToken",
                Authorization = "exampleAuthorization"
            };

            // Act
            var result = await GenericCaller.Call(type, action, content, config);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<string>();
            result.Should().NotBeEmpty();
        }
    }
}
