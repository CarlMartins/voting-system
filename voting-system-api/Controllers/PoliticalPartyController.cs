using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using voting_system_api.Entities;
using voting_system_api.Repositories;

namespace voting_system_api.Controllers
{
    public class PoliticalPartyController : BaseApiController
    {
        private readonly IPoliticalPartyRepository _repository;

        public PoliticalPartyController(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PoliticalParty>> GetPoliticalPartiesAsync()
        {
            var politicalParties = await _repository.GetAsync();

            return politicalParties;
        }
    }
}