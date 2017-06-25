using System.Data.Entity;

namespace LastTest.Models
{
    public class RoundContext : DbContext
    {
        public RoundContext() : base("ArkadiumDB")
        { }
        public DbSet<Round> Rounds { get; set; }
    }
}