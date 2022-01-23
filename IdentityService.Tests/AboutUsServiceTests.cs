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
    class AboutUsServiceTests
    {
        [Test]
        public void GetAboutUS_WhenCalled_ReturnResult()
        {
            var repository = Mock.Of<IRepository<AboutUs>>();
            var id = "Pasha";

            Mock.Get(repository).Setup(r => r.GetById(id)).Returns(new AboutUs());
            var result = repository.GetById(id);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetAboutUS_WhenCalled_ReturnNull()
        {
            var repository = Mock.Of<IRepository<AboutUs>>();
            var id = "";

            Mock.Get(repository).Setup(r => r.GetById(id));
            var result = repository.GetById(id);

            Assert.IsNull(result);
        }

        [Test]
        public void Delete_WhenCalled_Success()
        {
            var repository = new Mock<IRepository<AboutUs>>();
            string id = "1";

            repository.Object.Delete(id);

            repository.Verify(r => r.Delete(id), Times.Once);
        }
    }
}
