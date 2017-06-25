using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LastTest.Models;

namespace LastTest.Controllers
{
    public class RoundsController : ApiController
    {
        private RoundContext roundDB = new RoundContext();
        private MatchContext matchDB = new MatchContext();

        // GET: api/Rounds
        public IQueryable<Round> GetRounds()
        {
            return roundDB.Rounds;
        }

        // GET: api/Rounds/GetRoundsName 
        /// <summary>
        /// скисок матчей в раунде 
        /// </summary>
        /// <param name="id">Ид раунда</param>
        /// <returns></returns>
        [Route("api/Rounds/GetRoundsName")]
        public IHttpActionResult GetGetRoundsName()
        {
             
            // Round round = roundDB.Rounds.Find(id);
            var round = roundDB.Rounds.Select(x => x.RoundName);

            return Ok(round);
        }

        // GET: api/Rounds/GetMatchesInRound?id=5
        /// <summary>
        /// скисок матчей в раунде 
        /// </summary>
        /// <param name="id">Ид раунда</param>
        /// <returns></returns>
        [Route("api/Rounds/GetMatchesInRound")]
        public IHttpActionResult GetGetMatchesInRound(int id)
        {
             
            // Round round = roundDB.Rounds.Find(id);
            var ret = matchDB.Matches.Where(x => x.RoundId == id); 

            return Ok(ret);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                roundDB.Dispose();
                matchDB.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoundExists(int id)
        {
            return roundDB.Rounds.Count(e => e.RoundId == id) > 0;
        }
    }
}