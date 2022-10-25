using System.ComponentModel.DataAnnotations;

namespace JobMicroserviceAPI.Models.DTO
{
    public class JobDto
    {
        public int Id { get; set; }

        public string JobName { get; set; }

        public string JobDescription { get; set; }

        public string JobType { get; set; }

        public string CompanyName { get; set; }

        public int? CompanySize { get; set; }

        public string JobLocation { get; set; }

        public int Openings { get; set; }

        public double? MinPackage { get; set; }

        public double? MaxPackage { get; set; }

        public int MinExp { get; set; }

        public string? Perk { get; set; }

        public DateTime? JobPostDate { get; set; }

        public string? Status { get; set; }

        public int? CountOfApplicants { get; set; }

        public int? OpenApplicationCount { get; set; }
    }
}
