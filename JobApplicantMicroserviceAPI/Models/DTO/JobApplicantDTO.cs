namespace JobApplicantMicroserviceAPI.Models.DTO
{
    public class JobApplicantDTO
    {
        public int JobApplicantId { get; set; }

        public string ApplicationStatus { get; set; }

        //public Byte[]? UserResume { get; set; }

        public int JobId { get; set; }
       // public string? Job { get; set; }

        public int UserId { get; set; }
        //public string? User { get; set; }
        public string Resume { get; set; }
    }
}
