namespace Forum.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Forum.Data;

    public abstract class BaseApiController : ApiController
    {
        protected IForumData data;
        public BaseApiController(IForumData data)
        {
            this.data = data;
        }
    }
}
