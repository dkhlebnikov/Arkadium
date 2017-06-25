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
    public class BoxersController : ApiController
    {
        private RoundContext roundDB = new RoundContext();
        private MatchContext matchDB = new MatchContext();
        private CountryContext countyDB = new CountryContext();
        private MatchResultContext matchResultDB = new MatchResultContext();
        private BoxerContext boxerDB = new BoxerContext();


        // GET: api/Boxers
        public IQueryable<Boxer> GetBoxers()
        {
            return boxerDB.Boxers;
        }

        // GET: api/Boxers/5
        // Возвращает информацию о боксере и результатам его боев
        // наверное, это кастыльная реализация :) 
        public IHttpActionResult GetBoxer(int id)
        {
            var boxer = boxerDB.Boxers.Where(x => x.BoxerId == id); 

            var countryId = boxer.First().CountryId;

            var countryName = countyDB.Countries.First(x => x.CountryId == countryId).CountryShortName;
            int boxerId = boxer.First().BoxerId;

            var matches = matchDB.Matches.Where(x => x.FirstBoxerId == boxerId || x.SecondBoxerId == boxerId);

            var b = new BoxerInfo
            {
                BoxerName = boxer.First().BoxerName,
                CountryShortName = countryName,
                RoundResults = new List<RoundResult>()
            };

            foreach (var match in matches)
            {
                var res = new RoundResult();

                var roundName = roundDB.Rounds.First(x => x.RoundId == match.RoundId).RoundName;
                res.RoundName = roundName;

                var result = matchResultDB.MatchResults.First(x => x.BoxerId == boxerId && x.MatchId == match.MatchId).ResultName;
                res.ResultName = result;
                b.RoundResults.Add(res); 
            }
 
            return Ok(b);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                roundDB.Dispose();
                matchDB.Dispose();
                countyDB.Dispose();
                matchResultDB.Dispose();
                boxerDB.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}