using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Habanero.Services;

namespace Habanero.Web.Controllers
{
    public class ZipsController : ApiController
    {
        private IZipService _zipService;

        public ZipsController(IZipService zipService)
        {
            _zipService = zipService;
        }

        [Route("habanero/zips/{statecode}")]
        public IHttpActionResult GetZipsByState(string statecode)
        {
            if ((String.IsNullOrEmpty(statecode)) || String.IsNullOrWhiteSpace(statecode))
            {
                return BadRequest("statecode is Empty");
            }

            var zips = _zipService.GetZipsByState(statecode);
            return Ok(zips);
        }
    }
}
