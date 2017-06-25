using System.Data.Entity;

namespace LastTest.Models
{
    public class BoxerContext : DbContext
    {
        public BoxerContext() : base("ArkadiumDB")
        { }
        public DbSet<Boxer> Boxers { get; set; }
    }
}