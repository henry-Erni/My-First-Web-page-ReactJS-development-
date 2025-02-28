using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using quiz_app.DTO;
using quiz_app.Entities;
using quiz_app.Repositories.QuizRecordInterface;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Xunit;

public class QuizControllerTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;
    private readonly Mock<IQuizRecordRepository> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;

    public QuizControllerTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                _mockRepository = new Mock<IQuizRecordRepository>();
                _mockMapper = new Mock<IMapper>();
                services.AddSingleton(_mockRepository.Object);
                services.AddSingleton(_mockMapper.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task CreateQuizRecord_AdminUser_ReturnsOk()
    {
        // Arrange
        var data = new QuizRecordDTO { /* Initialize properties */ };
        var responseDto = new QuizRecordResponseDTO { /* Initialize properties */ };

        _mockRepository.Setup(repo => repo.CreateQuizRecordAsync(data))
            .ReturnsAsync(new QuizRecord { /* Initialize properties */ });
        _mockMapper.Setup(m => m.Map<QuizRecordResponseDTO>(It.IsAny<QuizRecord>()))
            .Returns(responseDto);

        // Act
        var request = new HttpRequestMessage(HttpMethod.Post, "/createrecord")
        {
            Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        };
        // Simulate admin user authentication here
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "admin_token");

        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task CreateQuizRecord_NonAdminUser_ReturnsUnauthorized()
    {
        // Arrange
        var data = new QuizRecordDTO { /* Initialize properties */ };

        // Act
        var request = new HttpRequestMessage(HttpMethod.Post, "/createrecord")
        {
            Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
        };
        // Simulate non-admin user authentication here
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "non_admin_token");

        var response = await _client.SendAsync(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}