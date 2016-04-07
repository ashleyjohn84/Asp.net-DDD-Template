using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habanero.Domain;
using Habanero.Domain.Entities;
using Habanero.Services;
using Moq;
using NUnit.Framework;

namespace Habanero.Tests
{
    [TestFixture]
    public class ServicesTest
    {
        private readonly MockData _mockData = new MockData();

        [Test]
        public void GetAllStatesReturnAllStatesInRepo()
        {
            var mockStateRepository = new Mock<IRepository<State>>();
            mockStateRepository.Setup(mock => mock.Get()).Returns(_mockData.GetMockStates);
            StateService stateService = new StateService(mockStateRepository.Object);
            var states = stateService.GetAllStates();
            Assert.That(states.Count,Is.EqualTo(4));
            Assert.That(states.Select(s => s.Name).ToArray(), Is.EquivalentTo(new []{"Alaska", "California", "Colorado", "Hawaii"}.AsEnumerable()));
        }

        [Test]
        public void GetAllPrimaryStatesReturnsOnlyStatesWhereIsPrimaryIsTrue()
        {
            var mockStateRepository = new Mock<IRepository<State>>();
            mockStateRepository.Setup(mock => mock.Get()).Returns(_mockData.GetMockStates);
            StateService stateService = new StateService(mockStateRepository.Object);
            var states = stateService.GetAllPrimaryStates();
            Assert.That(states.Count, Is.EqualTo(3));
            Assert.That(states.Select(s => s.Name).ToArray(), Is.EquivalentTo(new[] { "Alaska", "California", "Colorado" }.AsEnumerable()));
        }

        [Test]
        public void GetZipsByStateReturnsZipsWithStateCodeMatchingAbbreviation()
        {
            var mockZipRepository = new Mock<IRepository<ZipCode>>();
            mockZipRepository.Setup(mock => mock.Get()).Returns(_mockData.GetZipCodes);
            ZipService service = new ZipService(mockZipRepository.Object);
            var zipCodes = service.GetZipsByState("AK");
            Assert.That(zipCodes.Count,Is.EqualTo(3));
            Assert.That(zipCodes.Select(zip => zip.StateName).ToArray(), Has.All.Contains("Alaska"));
        }
    }
}
