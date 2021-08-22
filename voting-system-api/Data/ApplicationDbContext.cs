using Microsoft.EntityFrameworkCore;
using voting_system_api.Entities;

namespace voting_system_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<PoliticalParty> PoticalParties { get; set; }
    }
}