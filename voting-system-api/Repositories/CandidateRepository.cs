using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using voting_system_api.Data;
using voting_system_api.Entities;

namespace voting_system_api.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidate> GetAsync(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task Create(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userToDelete = _context.Candidates
                .FirstOrDefaultAsync(u => u.CandidateId == id);
            if (userToDelete != null)
            {
                _context.Candidates.Remove(userToDelete.Result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Candidate candidate)
        {
            var userToUpdate = _context.Candidates
                .FirstOrDefaultAsync(u => u.CandidateId == candidate.CandidateId);

            if (userToUpdate != null)
            {
                userToUpdate.Result.Name = candidate.Name;
                userToUpdate.Result.PoliticalPartyId = candidate.PoliticalPartyId;
                userToUpdate.Result.Votes = candidate.Votes;
                userToUpdate.Result.Number = candidate.Number;
                await _context.SaveChangesAsync();
            }
        }
    }
}