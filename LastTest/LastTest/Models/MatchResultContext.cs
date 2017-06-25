using System.Data.Entity;

namespace LastTest.Models
{
    public class MatchResultContext : DbContext
    {
        public MatchResultContext() : base("ArkadiumDB")
        { }
        public DbSet<MatchResult> MatchResults { get; set; }
    }
}