using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Habanero.Services;
using Habanero.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace Habanero.Tests
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public void ControllerShouldCallGetAllStates()
        {
            Mock<IStateService> stateService = new Mock<IStateService>();
            var statesController = new StatesController(stateService.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost/habanero/states")
                }
            };
            statesController.Configuration.MapHttpAttributeRoutes();
            statesController.Configuration.EnsureInitialized();
            var result = statesController.Get();
            stateService.Verify(service => service.GetAllStates(), Times.Once);
        }

        [Test]
        public void ControllerShouldCallGetAllPrimaryStates()
        {
            Mock<IStateService> stateService = new Mock<IStateService>();
            var statesController = new StatesController(stateService.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost/habanero/primarystates")
                }
            };
            statesController.Configuration.MapHttpAttributeRoutes();
            statesController.Configuration.EnsureInitialized();
            var result = statesController.GetAllPrimaryStates();
            stateService.Verify(service => service.GetAllPrimaryStates(), Times.Once);
        }

        [Test]
        public void ZipControllerShouldCallGetZipsByState()
        {
            Mock<IZipService> zipService = new Mock<IZipService>();
            MockData data = new MockData();
            zipService.Setup(service => service.GetZipsByState(It.IsAny<string>())).Returns(data.GetZipModels);
            var zipController = new ZipsController(zipService.Object)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://localhost/habanero/zips/AK")
                }
            };
            zipController.Configuration.MapHttpAttributeRoutes();
            zipController.Configuration.EnsureInitialized();
            var result = zipController.GetZipsByState("AK");
            zipService.Verify(service => service.GetZipsByState("AK"), Times.Once);
        }
    }
}
