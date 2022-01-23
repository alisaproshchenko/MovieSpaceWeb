using System.Collections.Generic;
using MoviesService.Models;
using MoviesService.Search;
using NUnit.Framework;

namespace MoviesService.Tests
{
    [TestFixture]
    class SearchInDataBaseTests
    {
        private SearchInDataBase _search;
        public List<Media> MediaList = new List<Media>
        {
            new Media{Name = "A",Year = 2021, Types = new Types{Id = 1, Name = "1"}},
            new Media{Name = "B",Year = 2020, Types = new Types{Id = 2, Name = "2"}},
            new Media{Name = "C",Year = 2017, Types = new Types{Id = 1, Name = "3"}},
            new Media{Name = "D",Year = 2020, Types = new Types{Id = 2, Name = "3"}},
        };

        [SetUp]
        public void Setup()
        {
            _search = new SearchInDataBase();
        }

        [Test]
        [TestCase("2021", 1)]
        [TestCase("2020", 2)]
        [TestCase("2030", 0)]
        public void SearchByYear_WhenCalled_CountIsCorrect(string year, int expectedResult)
        {
            var result = _search.SearchByYear(year, MediaList).Count;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("3", 2)]
        [TestCase("4", 0)]
        public void SearchByType_WhenCalled_CountIsCorrect(string type, int expectedResult)
        {
            var result = _search.SearchByType(type, MediaList).Count;

            Assert.AreEqual(expectedResult, result);
        }
    }
}
