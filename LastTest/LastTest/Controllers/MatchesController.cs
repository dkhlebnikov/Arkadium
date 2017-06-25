using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LastTest.Models;

namespace LastTest.Controllers
{
    public class MatchesController : ApiController
    {
        private MatchContext db = new MatchContext();

        // GET: api/Matches
        public IQueryable<Match> GetMatches()
        {
            return db.Matches;
        }

        // GET: api/Matches/5
        [ResponseType(typeof(Match))]
        public IHttpActionResult GetMatch(int id)
        {
            Match match = db.Matches.Find(id);
            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
         

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchExists(int id)
        {
            return db.Matches.Count(e => e.MatchId == id) > 0;
        }
    }
}