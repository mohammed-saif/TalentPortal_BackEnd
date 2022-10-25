namespace UserSkillMicroserviceAPI.Models.DTO
{
    public class UserSkillDTO
    {
        //[Key]
        public int UserSkillId { get; set; }

        // [ForeignKey("User")]
        public int? UserId { get; set; }
        // public User? User { get; set; }

        //[ForeignKey("Skill")]
        public int? SkillId { get; set; }

    }
}
