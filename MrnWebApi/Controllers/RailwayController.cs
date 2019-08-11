using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MrnWebApi.Controllers
{
    [Route(RAILWAY_PATH)]
    [ApiController]
    public class RailwayController : ApiController
    {
        public const String RAILWAY_PATH = API_PATH + "/railway";

        // GET: api/Railway
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/Railway/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/Railway
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Railway/5
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
