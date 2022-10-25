using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JobApplicantMicroserviceAPI.CustomAnnotations;

namespace JobApplicantMicroserviceAPI.Models.Domain
{
    public class JobApplicant
    {
        [Key]
        public int JobApplicantId { get; set; }

        [Required]
        [ApplicationStatusLimitation]
        public string ApplicationStatus { get; set; }

        [Required]
        //[ForeignKey("Job")]
        public int JobId { get; set; }
        //public string? Job { get; set; }

        [Required]
        //[ForeignKey("User")]
        public int UserId { get; set; }
        //public string? User { get; set; }

        [Required]
        public string Resume { get; set; }

    }
}
