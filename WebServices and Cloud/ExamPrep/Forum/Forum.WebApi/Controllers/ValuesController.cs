using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Forum.WebApi.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        private int calls;
        private DateTime time;
        public ValuesController()
            :base()
        {
            calls = 0;
            time = DateTime.Now;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            calls++;
            return new string[] { calls.ToString(), time.ToString() };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
