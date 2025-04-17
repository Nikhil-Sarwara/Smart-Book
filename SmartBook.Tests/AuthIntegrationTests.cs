using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SmartBook.Api.Dtos.Requests;
using SmartBook.Api.Dtos.Responses;
using SmartBook.Database.Data;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace SmartBook.Tests.IntegrationTests
{
    public class AuthIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;
        private static string _authToken; // Store the token for subsequent requests

        public AuthIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Get the environment
                    var environment = _factory.Services.GetRequiredService<IWebHostEnvironment>();
                    var basePath = Path.Combine(environment.ContentRootPath, "..", "..", "SmartBook.Api");

                    // Get the connection string from the test appsettings.json
                    var configuration = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json")
                        .Build();

                    var connectionString = configuration.GetConnectionString("DefaultConnection");

                    // Attempt to open a connection to the database
                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            Console.WriteLine("Successfully connected to the database.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error connecting to the database: {ex.Message}");
                        // You might want to handle this more severely in a real scenario,
                        // perhaps by throwing an exception to prevent tests from running
                        // if the database connection is essential.
                    }

                    // Remove the app's default database context configuration
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(DbContextOptions<ApplicationDbContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    // Remove any existing ApplicationDbContext registration
                    var appDbContextDescriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(ApplicationDbContext));
                    if (appDbContextDescriptor != null)
                    {
                        services.Remove(appDbContextDescriptor);
                    }

                    // Add the ApplicationDbContext using SQL Server
                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    // Get the service provider
                    var sp = services.BuildServiceProvider();

                    // Create a scope to obtain a reference to the database context
                    using (var scope = sp.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices.GetRequiredService<ApplicationDbContext>();

                        // Ensure the database is created (and apply migrations if needed)
                        db.Database.Migrate(); // Use Migrate() instead of EnsureCreated() for SQL Server
                    }
                });
            });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task CanRegisterUser()
        {
            // Arrange
            var registrationDto = new RegisterRequestDto
            {
                Email = "testuser@example.com",
                Password = "P@$$wOrd123",
                ConfirmPassword = "P@$$wOrd123"
            };
            var content = JsonContent.Create(registrationDto);

            // Act
            var response = await _client.PostAsync("/api/auth/register", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthResponseDto>(responseContent);
            Assert.NotNull(authResponse?.Token);
            Assert.Equal(registrationDto.Email, authResponse?.Email);

            // Store the token for future tests
            _authToken = authResponse.Token;
        }

        [Fact]
        public async Task CanLoginUser()
        {
            // Arrange
            var loginDto = new LoginRequestDto
            {
                Email = "testuser@example.com", // Use the same email as registered
                Password = "P@$$wOrd123"
            };
            var content = JsonContent.Create(loginDto);

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthResponseDto>(responseContent);
            Assert.NotNull(authResponse?.Token);
            Assert.Equal(loginDto.Email, authResponse?.Email);

            // Store the token if not already stored during registration
            if (string.IsNullOrEmpty(_authToken))
            {
                _authToken = authResponse.Token;
            }
        }

        [Fact]
        public async Task LoginFailsWithInvalidCredentials()
        {
            // Arrange
            var loginDto = new LoginRequestDto
            {
                Email = "testuser@example.com",
                Password = "WrongPassword"
            };
            var content = JsonContent.Create(loginDto);

            // Act
            var response = await _client.PostAsync("/api/auth/login", content);

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task PublicEndpointIsAccessibleWithoutToken()
        {
            // Act
            var response = await _client.GetAsync("/api/testauth/public");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("public", content);
        }

        [Fact]
        public async Task ProtectedEndpointRequiresAuthentication()
        {
            // Act
            var response = await _client.GetAsync("/api/testauth/protected");

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ProtectedEndpointIsAccessibleWithValidToken()
        {
            // Arrange
            // Ensure a token is available (register and/or login if needed)
            if (string.IsNullOrEmpty(_authToken))
            {
                await CanRegisterUser(); // Or await CanLoginUser();
            }

            // Act
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/testauth/protected");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _authToken);
            var response = await _client.SendAsync(request);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("protected", content);
        }
    }
}