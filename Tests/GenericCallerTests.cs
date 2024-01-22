using Xunit;
using FluentAssertions;
using ApiBrasil;
using ApiBrasil.Domain;

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
                number =  1,
                text = "Olá"
            };

            var config = new ApiBrasilConfiguration
            {
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

        [Fact]
        public async Task Call_ShouldThrowArgumentNullException()
        {
            // Arrange
            var type = "exampleType";
            var action = "exampleAction";
            object? content = null; // Definir content como null para gerar ArgumentNullException
            var config = new ApiBrasilConfiguration
            {
                DeviceToken = "exampleDeviceToken",
                Authorization = "exampleAuthorization"
            };

            // Act
            Func<Task> func = async () => await GenericCaller.Call(type, action, content, config);

            // Assert
            await func.Should().ThrowAsync<ArgumentNullException>();
        }

    }
}
