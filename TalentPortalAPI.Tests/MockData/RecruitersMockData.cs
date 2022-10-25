using RecruiterMicroserviceAPI.Models.Domain;

namespace RecruiterMicroserviceAPI.Tests.MockData
{
    internal class RecruitersMockData
    {
        public static List<Recruiter> AllRecruiters()
        {
            return new List<Recruiter>
            {
                new() {UserId = 1, JobId = 1},
                new() {UserId = 1, JobId = 4},
                new() {UserId = 2, JobId = 1},
                new() {UserId = 3, JobId = 2},
                new() {UserId = 2, JobId = 2},
                new() {UserId = 4, JobId = 3}
            };
        }

        public static List<Recruiter> EmptyRecruitersList()
        {
            return new List<Recruiter>();
        }

        public static Recruiter ValidRecruiter()
        {
            return new Recruiter()
            {
                UserId = 4,
                JobId = 4
            };
        }

        public static Recruiter InvalidRecuiter()
        {
            return new Recruiter()
            {
                UserId = 4, 
                JobId = 3
            };
        }

        public static Recruiter ValidRecruiterForDelete()
        {
            var rec = new Recruiter()
            {
                UserId = 4,
                JobId = 3
            };

            return rec;
        }

        public static Recruiter InvalidRecruiterForDelete()
        {
            var rec = new Recruiter()
            {
                UserId = 4,
                JobId = 4
            };

            return rec;
        }



        public static Recruiter NullRecruiter()
        {
            return null;
        }
    }
}
