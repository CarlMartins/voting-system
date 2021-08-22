using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voting_system_api.Entities;

namespace voting_system_api.Repositories
{
    public interface IPoliticalPartyRepository
    {
        Task<IEnumerable<PoliticalParty>> GetAsync();
        Task <PoliticalParty> GetAsync(int id);
        Task <IEnumerable<Candidate>> GetCandidatesAsync(int politicalParty);
        Task Create(PoliticalParty politicalParty);
        Task Delete(int id);
        Task Update(PoliticalParty politicalParty);
    }
}