using JobMicroserviceAPI.Models.Domain;

namespace JobMicroserviceAPI.Tests.MockData
{
    public static class JobsMockData
    {
        public static List<Job> GetJobs()
        {
            return new List<Job>
            {
                new (){Id=1,JobName = "Software Developer", JobDescription = "Frontend software developer is required",
                JobType = "Full-Time", CompanyName = "ABC", CompanySize = 7000, JobLocation = "Bangalore",
                Openings = 5, MinPackage = 2.5, MaxPackage = 5, MinExp = 2, Perk = "snacks, paid leave",
                JobPostDate = new DateTime(2022/09/27), Status = "open", CountOfApplicants = 1, OpenApplicationCount = 1 },

                new (){Id=2,JobName = "Software Developer", JobDescription = "Frontend software developer is required",
                JobType = "Full-Time", CompanyName = "ABC", CompanySize = 7000, JobLocation = "Bangalore",
                Openings = 5, MinPackage = 2.5, MaxPackage = 5, MinExp = 2, Perk = "snacks, paid leave",
                JobPostDate = new DateTime(2022/09/27), Status = "open", CountOfApplicants = 1, OpenApplicationCount = 1 },

                new (){Id=3,JobName = "Software Developer", JobDescription = "Frontend software developer is required",
                JobType = "Full-Time", CompanyName = "ABC", CompanySize = 7000, JobLocation = "Bangalore",
                Openings = 5, MinPackage = 2.5, MaxPackage = 5, MinExp = 2, Perk = "snacks, paid leave",
                JobPostDate = new DateTime(2022/09/27), Status = "open", CountOfApplicants = 1, OpenApplicationCount = 1 }
            };
        }

        public static List<Job> EmptyJobsList()
        {
            return new List<Job>();
        }

        public static Job Job()
        {
            return new Job()
            {
                Id = 1,
                JobName = "Software Developer",
                JobDescription = "Frontend software developer is required",
                JobType = "Full-Time",
                CompanyName = "ABC",
                CompanySize = 7000,
                JobLocation = "Bangalore",
                Openings = 5,
                MinPackage = 2.5,
                MaxPackage = 5,
                MinExp = 2,
                Perk = "snacks, paid leave",
                JobPostDate = new DateTime(2022 / 09 / 27),
                Status = "open",
                CountOfApplicants = 1,
                OpenApplicationCount = 1
            };
        }



        public static Job EmptyJob()
        {
            return null;

        }
    }
}
