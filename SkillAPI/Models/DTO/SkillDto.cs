using System.ComponentModel.DataAnnotations;

namespace SkillMicroserviceAPI.Models.DTO
{
    public class SkillDto
    {
        [Required]
        public int  SkillId { get; set; }
        [Required]
        public string SkillName { get; set; }
    }
}
