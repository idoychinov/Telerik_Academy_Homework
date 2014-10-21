using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebApiApp.Controllers
{
    public class SumController : ApiController
    {
        // GET api/values
        public int Get(int a, int b)
        {
            return a+b;
        }

    }
}
