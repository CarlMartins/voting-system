using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using voting_system_api.Data;
using voting_system_api.Entities;

namespace voting_system_api.Repositories
{
    public class PoliticalPartyRepository : IPoliticalPartyRepository
    {
        private readonly ApplicationDbContext _context;
        public PoliticalPartyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PoliticalParty>> GetAsync()
        {
            var politicalParties = await _context.PoticalParties.ToListAsync();

            return politicalParties;
        }

        public async Task<PoliticalParty> GetAsync(int id)
        {
            var politicalParty = await _context.PoticalParties.FindAsync(id);

            return politicalParty;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesAsync(int politicalParty)
        {
            var candidates = await _context.Candidates.Where(a => a.PoliticalPartyId == politicalParty)
                .ToListAsync();

            return candidates;
        }

        public async Task Create(PoliticalParty politicalParty)
        {
            await _context.PoticalParties.AddAsync(politicalParty);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            PoliticalParty politicalParty = await _context.PoticalParties
                .Where(p => p.Id == id)
                .SingleOrDefaultAsync();

            if (politicalParty != null)
            {
                _context.PoticalParties.Remove(politicalParty);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(PoliticalParty politicalParty)
        {
            var partyToUpdate = await _context.PoticalParties
                .Where(p => p.Id == politicalParty.Id)
                .SingleOrDefaultAsync();

            if (politicalParty != null)
            {
                partyToUpdate.Name = politicalParty.Name;
            }

            await _context.SaveChangesAsync();
        }
    }
}