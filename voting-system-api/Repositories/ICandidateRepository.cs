using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voting_system_api.Entities;

namespace voting_system_api.Repositories
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetAsync(int id);
        Task CreateAsync(Candidate candidate);
        Task DeleteAsync(int id);
        Task UpdateAsync(Candidate candidate);
    }
}