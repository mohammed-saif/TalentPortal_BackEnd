using JobApplicantMicroserviceAPI.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicantMicroserviceAPI.Test.MockData
{
    public class JobApplicantMockData
    {
        public static List<JobApplicant> ListAllJobApplicant()
        {
            return new List<JobApplicant>()
            {
                new()
                {
                    ApplicationStatus="submitted",
                    JobId=101,
                    UserId=10
                },

                new()
                {
                    //JobApplicantId=2,
                    ApplicationStatus ="rejected",
                    JobId = 105,
                    UserId=27
                },

                new()
                {
                    //JobApplicantId=3,
                    ApplicationStatus="submitted",
                    JobId=208,
                    UserId=4
                }
            };
        }

        public static List<JobApplicant> EmptyJobApplicantList()
        {
            return new List<JobApplicant>();
            //return null;
        }
        //trying

        public static JobApplicant ValidJobApplicant()
        {
            return new JobApplicant()
            {
                JobApplicantId = 3,
                ApplicationStatus = "submitted",
                JobId=208,
                UserId=4
                
            };
        }
        public static List<JobApplicant> EmptyJobApplicantJobList()
        { 
            return null;
        }



        public static JobApplicant EmptyJobApplicant()
        {
            return null;
        }
    }
}
