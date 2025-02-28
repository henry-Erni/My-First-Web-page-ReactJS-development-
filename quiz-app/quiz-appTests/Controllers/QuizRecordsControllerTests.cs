using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using quiz_app.Controllers;
using quiz_app.Entities;
using System.Security.Claims;
using AutoMapper;
using quiz_app.Repositories.QuizRecordInterface;

namespace quiz_app.Controllers.Tests
{
    [TestClass()]
    public class QuizRecordsControllerTests
    {
        private QuizRecordsController? _controller;
        private Mock<IQuizRecordRepository>? _mockQuizRecordRepository;
        private Mock<IMapper>? _mockMapper;

        [TestInitialize]
        public void Setup()
        {
            _mockQuizRecordRepository = new Mock<IQuizRecordRepository>();
            _mockMapper = new Mock<IMapper>();

            _controller = new QuizRecordsController(_mockQuizRecordRepository.Object, _mockMapper.Object);
        }

        [TestMethod()]
        public void CreateQuizRecord_AdminUser_ShouldAllowAccess()
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "Admin")
            }));

            _controller.ControllerContext.HttpContext.User = user;

            // Act
            var result = _controller.CreateQuizRecord(new QuizRecord());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod()]
        public void CreateQuizRecord_NonAdminUser_ShouldDenyAccess()
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "User") // Non-admin role
            }));

            _controller.ControllerContext.HttpContext.User = user;

            // Act
            var result = _controller.CreateQuizRecord(new QuizRecord());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ForbidResult));
        }
    }
}