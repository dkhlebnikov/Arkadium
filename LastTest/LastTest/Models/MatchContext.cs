using System.Data.Entity;

namespace LastTest.Models
{
    public class MatchContext : DbContext
    {
        public MatchContext() : base("ArkadiumDB")
        { }
        public DbSet<Match> Matches { get; set; }
    }
}