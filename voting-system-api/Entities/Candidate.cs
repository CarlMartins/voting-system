using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace voting_system_api.Entities
{
    public class Candidate : ICandidate
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }
        
        [Required(ErrorMessage = "The candidate name is required.")]
        [MinLength(3, ErrorMessage = "The candidate name needs to have 3 characters at least.")]
        [MaxLength(80, ErrorMessage = "The candidate name can not be longer than 80 characters.")]
        public int Name { get; set; }
        
        public PoliticalParty PoliticalParty { get; set; }

        [Required(ErrorMessage = "Political party ID is required.")]
        public int PoliticalPartyId { get; set; }
        
        [Required(ErrorMessage = "The number of the candidate is required.")]
        public string Number { get; set; }
        
        public int Votes { get; set; }
    }
}