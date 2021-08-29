using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voting_system_api.Entities;
using voting_system_api.Repositories;

namespace voting_system_api.Controllers
{
    public class CandidateController : BaseApiController
    {
        private readonly ICandidateRepository _repository;

        public CandidateController(ICandidateRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ICandidate>> GetCandidateAsync(int id)
        {
            var candidate = await _repository.GetAsync(id);

            return StatusCode(200, candidate);
        }

        [HttpPost]
        public async Task<ActionResult<ICandidate>> CreateCandidateAsync(Candidate candidate)
        {
            Candidate newCandidate = new()
            {
                Name = candidate.Name,
                Number = candidate.Number,
                PoliticalPartyId = candidate.PoliticalPartyId,
                Votes = 0,
            };

            await _repository.CreateAsync(newCandidate);
            return StatusCode(201, $"User {newCandidate.Name} created.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCandidateAsync(int id)
        {
            var existingItem = _repository.GetAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateCandidateAsync(int id, Candidate candidate)
        {
            var existingItem = await _repository.GetAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = candidate.Name;
            existingItem.Number = candidate.Number;
            existingItem.PoliticalPartyId = candidate.PoliticalPartyId;

            await _repository.UpdateAsync(existingItem);

            return NoContent();
        }

    }
}