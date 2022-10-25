using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserSkillMicroserviceAPI.Models.Domain
{
    public class UserSkill
    {
        [Key]
        public int UserSkillId { get; set; }

       // [ForeignKey("User")]
        public int ? UserId { get; set; }
       // public User? User { get; set; }

        //[ForeignKey("Skill")]
        public int ? SkillId { get; set; }
       

    }
}
