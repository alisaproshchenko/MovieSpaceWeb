using System.Collections.Generic;
using System.Linq;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Services;
using IdentityService.UOW;
using Moq;
using NUnit.Framework;

namespace IdentityService.Tests
{
    [TestFixture]
    class ApplicationUserServiceTests
    {
        [Test]
        public void DeleteUser_WhenCalled_Success()
        {
            var repository = new Mock<IRepository<ApplicationUser>>();
            string id = "1";

            repository.Object.Delete(id);

            repository.Verify(r => r.Delete(id), Times.Once);
        }

        [Test]
        public void ChangeUserData_WhenCalled_Success()
        {
            var repository = new Mock<IRepository<ApplicationUser>>();
            var applicationUser = new ApplicationUser();

            repository.Object.Update(applicationUser);

            repository.Verify(r => r.Update(applicationUser), Times.Once);
        }

        [Test]
        [TestCase("11111", "The minimum length of password is 6 characters")]
        [TestCase("aaaaaa", "At least one digit is needed in password")]
        [TestCase("aaaaa1", "At least one character in upper case is needed in password")]
        [TestCase("AAAAA1", "At least one character in lower case is needed in password")]
        public void Validate_WhenCalled_ErrorMessageGenerated(string password, string expectedError)
        {
            ApplicationUserService applicationUserService = new ApplicationUserService();

            var errors = applicationUserService.Validate(password).ToArray();

            Assert.Contains(expectedError, errors);
        }

        [Test]
        [TestCase("Aaaaa1")]
        public void Validate_WhenCalled_Success(string password)
        {
            ApplicationUserService applicationUserService = new ApplicationUserService();

            var errors = applicationUserService.Validate(password);

            Assert.IsEmpty(errors);
        }

        [Test]
        public void GetAll_WhenCalled_Success()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.UserRepository.GetAll()).Returns(new List<ApplicationUser>()
                { new ApplicationUser() { Name = "Pavlo", Banned = false, Surname = "Skachkov" }, 
                    new ApplicationUser() { Name = "Alisa", Banned = false, Surname = "Proshchenko" }});

            var users = mock.Object.UserRepository.GetAll();

            Assert.AreEqual(2, users.Count());
        }
    }
}
