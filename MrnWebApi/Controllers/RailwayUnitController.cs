using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MrnWebApi.Controllers
{
    [Route(RAILWAY_UNIT_PATH)]
    [ApiController]
    public class RailwayUnitController : ApiController
    {
        public const String RAILWAY_UNIT_PATH = API_PATH + "/railway-unit";
        // GET: api/RailwayUnit
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/RailwayUnit/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/RailwayUnit
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/RailwayUnit/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
