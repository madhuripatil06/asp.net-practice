using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class teamController : ApiController
    {
        private databaseEntities db = new databaseEntities();

        // GET: api/team
        [HttpGet]
        [Route("api/team")]
        public IQueryable<team> Getteams()
        {
            return db.teams;
        }

        // GET: api/team/memberName
        [HttpGet]
        [Route("api/team/{name}")]
        public IHttpActionResult Getteam(string name)
        {
            team team = db.teams.Find(name);
            if (team == null)
                return NotFound();
            
            return Ok(team);
        }

        // POST: api/team/member
        [HttpPost]
        [Route("api/team/{username}/{count}")]
        public IHttpActionResult createMember(string username, int count)
        {
            team member = new team();
            member.count = count;
            member.username = username;
            db.teams.Add(member);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return Ok();
        }


        // PUT: api/team/memberName
        [HttpPut]
        [Route("api/team/{name}/{count}")]
        public IHttpActionResult Putteam(string name, int count)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.teams.Find(name).count = count;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                 return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/team/memberName
        [HttpDelete]
        [Route("api/team/{name}")]
        public IHttpActionResult Deleteteam(string name)
        {
            team team = db.teams.Find(name);
            if (team == null)
            {
                return NotFound();
            }
            db.teams.Remove(team);
            db.SaveChanges();
            return Ok(team);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool teamExists(string id)
        {
            return db.teams.Count(e => e.username == id) > 0;
        }
    }
}