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

        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
