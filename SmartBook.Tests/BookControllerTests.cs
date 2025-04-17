using Xunit;
using SmartBook.Api.Controllers; // Assuming your controller is in this namespace
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SmartBook.Tests.Controllers
{
    public class BookControllerTests
    {
        [Fact]
        public void Get_ReturnsOkResult()
        {
            // Arrange
            var controller = new BooksController(); // You might need to inject dependencies later

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsAListOfBooks()
        {
            // Arrange
            var controller = new BooksController(); // You might need to inject dependencies later

            // Act
            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<List<string>>(okResult.Value); // Adjust the type based on your actual return type
            // Assert.True(((List<string>)okResult.Value).Any()); // Example assertion for non-empty list
        }

        // You can add more test methods here
    }
}
