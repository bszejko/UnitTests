using NUnit.Framework;
using Moq;
using TestProject2;
using System.Collections.Generic;
using NUnit.Framework.Internal;

namespace TestProject2.UnitTests
{
    [TestFixture]
    public class DataServiceTests
    {
        private Mock<IDataFetcher> _dataFetcherMock;
        private Mock<ILogger> _loggerMock;
        private Mock<IEmailService> _emailServiceMock;
        private Mock<ICacheService> _cacheServiceMock;
        private DataService _dataService;

        [SetUp]
        public void SetUp()
        {
            _dataFetcherMock = new Mock<IDataFetcher>();
            _loggerMock = new Mock<ILogger>();
            _emailServiceMock = new Mock<IEmailService>();
            _cacheServiceMock = new Mock<ICacheService>();
            _dataService = new DataService(_dataFetcherMock.Object, _loggerMock.Object, _emailServiceMock.Object, _cacheServiceMock.Object);
        }

        [Test]
        public void GetData_WhenCalled_ReturnsFetchedData()
        {
            _dataFetcherMock.Setup(df => df.FetchData()).Returns("data");

            var result = _dataService.GetData();

            Assert.That(result, Is.EqualTo("data"));
        }

        [Test]
        public void ProcessData_WhenCalled_ReturnsUppercaseData()
        {
            _dataFetcherMock.Setup(df => df.FetchData()).Returns("data");

            var result = _dataService.ProcessData();

            Assert.That(result, Is.EqualTo("DATA"));
        }

        [Test]
        public void ValidateData_WhenCalledWithNonEmptyString_ReturnsTrue()
        {
            var result = _dataService.ValidateData("data");

            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateData_WhenCalledWithEmptyString_ReturnsFalse()
        {
            var result = _dataService.ValidateData("");

            Assert.That(result, Is.False);
        }

        [Test]
        public void SplitData_WhenCalled_ReturnsListOfStrings()
        {
            var result = _dataService.SplitData("a,b,c");

            Assert.That(result, Is.EqualTo(new List<string> { "a", "b", "c" }));
        }

        [Test]
        public void LogData_WhenCalled_InvokesLogger()
        {
            var message = "log message";
            _dataService.LogData(message);

            _loggerMock.Verify(logger => logger.Log(message), Times.Once);
        }

        [Test]
        public void SendNotification_WhenCalled_InvokesEmailService()
        {
            var message = "email message";
            _dataService.SendNotification(message);

            _emailServiceMock.Verify(emailService => emailService.SendEmail(message), Times.Once);
        }

        [Test]
        public void GetCachedData_WhenCalled_ReturnsCachedData()
        {
            var key = "cacheKey";
            var value = "cached data";
            _cacheServiceMock.Setup(cacheService => cacheService.Get(key)).Returns(value);

            var result = _dataService.GetCachedData(key);

            Assert.That(result, Is.EqualTo(value));
        }

        [Test]
        public void CacheData_WhenCalled_InvokesCacheService()
        {
            var key = "cacheKey";
            var data = "data to cache";

            _dataService.CacheData(key, data);

            _cacheServiceMock.Verify(cacheService => cacheService.Set(key, data), Times.Once);
        }
    }
}
