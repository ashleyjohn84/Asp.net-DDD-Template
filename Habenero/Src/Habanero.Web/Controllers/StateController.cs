using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Habanero.Domain.Models;
using Habanero.Services;

namespace Habanero.Web.Controllers
{
    public class StatesController : ApiController
    {
        private IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [Route("habanero/states")]
        public HttpResponseMessage Get()
        {
            var states =  _stateService.GetAllStates();
            return Request.CreateResponse(HttpStatusCode.OK, states);
        }

        [Route("habanero/primarystates")]
        public HttpResponseMessage GetAllPrimaryStates()
        {
            var primaryStates =  _stateService.GetAllPrimaryStates();
            return Request.CreateResponse(HttpStatusCode.OK, primaryStates);
        }
    }
}
