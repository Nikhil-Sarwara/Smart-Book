#!/bin/bash

TEST_PROJECT_DIR="SmartBook.Tests"
TEST_FILE_NAME="BookControllerTests.cs"
TEST_FILE_PATH="$TEST_PROJECT_DIR/$TEST_FILE_NAME"

# Create the test file
touch "$TEST_FILE_PATH"

# Add basic test code to the file
cat > "$TEST_FILE_PATH" << EOM
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
EOM

# Add the new file to Git
git add "$TEST_FILE_PATH"

# Commit the changes
git commit -m "Add initial BookControllerTests file with example tests"

echo "Successfully created '$TEST_FILE_PATH' and added some example test code."
echo "Remember to add necessary project references in your 'SmartBook.Tests' project (e.g., reference to 'SmartBook.Api')."