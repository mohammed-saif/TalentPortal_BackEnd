using System.ComponentModel.DataAnnotations;

namespace JobSkillMicroservicesAPI.Models.Domain
{
    public class JobSkill
    {
        [Required]
        public int JobSkillId { get; set; }

        [Required]
        public int JobId { get; set; }


        [Required]
        public int SkillId { get; set; }

        public string? SkillName { get; set; }
    }
}
