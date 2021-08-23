using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voting_system_api.Entities;

namespace voting_system_api.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetAsync(int id);
        Task Create(Candidate candidate);
        Task Delete(int id);
        Task Update(Candidate candidate);
    }
}