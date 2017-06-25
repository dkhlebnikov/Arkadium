using System.Data.Entity;

namespace LastTest.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext() : base("ArkadiumDB")
        { }
        public DbSet<Country> Countries { get; set; }
    }
}