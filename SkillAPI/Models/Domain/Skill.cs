using System.ComponentModel.DataAnnotations;

namespace SkillAPI.Models.Domain
{
    public class Skill
    {
        [Required]
        public int SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }    
    }
}
