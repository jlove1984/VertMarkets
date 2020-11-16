using Moq;
using NUnit.Framework;
using VertMarkets.MagazineStore.API.Model;
using VertMarkets.MagazineStore.Core.Interfaces;
using VertMarkets.MagazineStore.Core.Services;

namespace VertMarkets.MagazineStore.Core.Tests
{
    public class Tests
    {
        private readonly MagazineService _sut;
        private readonly Mock<Magazine> _mockMagazine;
        private readonly Mock<string> _mockCategory;
        private readonly Mock<ApiSubscriber> _mockSubscriber;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}