namespace BugLogger.RestService.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Description;
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Models;

    public class BugsController : ApiController
    {
        private IGenericRepository<Bug> db;

        public BugsController()
            : this(new BugLoggerRepository<Bug>(new BugLoggerContext()))
        {
        }

        public BugsController(IGenericRepository<Bug> db)
        {
            this.db = db;
        }

        [HttpGet]
        [ResponseType(typeof(IQueryable<Bug>))]
        public IHttpActionResult Get()
        {
            return Ok(this.db.All());
        }

        [HttpGet]
        public IHttpActionResult Get(string date)
        {
            if (date == null)
            {
                return BadRequest("No filter date supplied.");
            }

            try
            {
                var parsedDate = DateTime.Parse(date);
                return Ok(this.db.All().Where(x => x.LogDate >= parsedDate));
            }
            catch
            {
                return BadRequest("Invalid date parameter");
            }

        }

        [HttpGet]
        public IHttpActionResult Get(Status status)
        {
            return Ok(this.db.All().Where(x => x.Status == status));
        }

        [HttpPost]
        public IHttpActionResult Post(Bug bug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bug.LogDate = DateTime.Now;
            bug.Status = Status.Pending;

            db.Add(bug);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bug.Id }, bug);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Status status)
        {
            this.db.Find(id).Status = status;
            this.db.SaveChanges();

            return Ok();
        }

    }
}
