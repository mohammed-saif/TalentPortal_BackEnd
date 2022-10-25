using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecruiterMicroserviceAPI.Models.Domain
{
    public class Recruiter
    {
        [Key]
        public int RecruiterId { get; set; }

        [Required]
        //[ForeignKey("User")]
        public int UserId { get; set; }
        //public User? User { get; set; }

        //[Required]
        //[ForeignKey("Dept")]
        //public int DeptId { get; set; }
        //public Dept Dept { get; set; }

        [Required]
        //[ForeignKey("Job")]
        public int JobId { get; set; }
        //public Job? Job { get; set; }
    }
}
