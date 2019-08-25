using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DatabaseAPI.Controllers
{
    [Route(RAILWAY_PATH)]
    [ApiController]
    public class RailwayController : ApiController
    {
        public const String RAILWAY_PATH = API_PATH + "/railway";

        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
