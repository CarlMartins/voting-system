using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace voting_system_api.Entities
{
    public class PoliticalParty : IPoliticalParty
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The political party name is required.")]
        [MinLength(3, ErrorMessage = "The political party needs to have 3 characters at least.")]
        [MaxLength(80, ErrorMessage = "The political party can not be longer than 80 characters.")]
        public string Name { get; set; }
        
        public List<Candidate> Candidates { get; set; }
    }
}