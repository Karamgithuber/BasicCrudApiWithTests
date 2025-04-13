using BasicCrudApiWithTests.Models;
using BasicCrudApiWithTests.Repositories;
using BasicCrudApiWithTests.Services;
using Moq;
using Xunit;

namespace BasicCrudApiWithTests.Tests
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService _service;
        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _service = new UserService(_mockRepo.Object);
        }
        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnUserList()
        {
            // Arrange
            var users = new List<User> { new User { Id = 1, UserName = "TestUser" } };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _service.GetAllUsersAsync();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            var user = new User { Id = 1, UserName = "John" };
            _mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

            var result = await _service.GetUserByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("John", result?.UserName);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnCreatedUser()
        {
            var newUser = new User { Id = 2, UserName = "Jane" };
            _mockRepo.Setup(r => r.AddAsync(newUser)).ReturnsAsync(newUser);

            var result = await _service.CreateUserAsync(newUser);

            Assert.Equal("Jane", result.UserName);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldInvokeRepository()
        {
            var updateUser = new User { Id = 3, UserName = "Updated" };

            await _service.UpdateUserAsync(updateUser);

            _mockRepo.Verify(r => r.UpdateAsync(updateUser), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldInvokeRepository()
        {
            await _service.DeleteUserAsync(4);

            _mockRepo.Verify(r => r.DeleteAsync(4), Times.Once);
        }
    }
}
