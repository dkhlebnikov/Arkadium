using System.Data.Entity;

namespace LastTest.Models
{
    public class ResultContext : DbContext
    {
        public ResultContext() : base("ArkadiumDB")
        { }
        public DbSet<Result> Results { get; set; }
    }
}