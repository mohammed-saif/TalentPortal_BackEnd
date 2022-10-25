using UserMicroserviceAPI.Models.Domain;

namespace UserMicroserviceAPI.Tests.MockData
{
    public static class UserMockData
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new(){ UserId=1,UserFirstName="Kiranmaya",UserLastName="Puhan",UserDOB=new DateTime(2000,08,22),
                       Gender="M",UserPhoneNumber=1111111111,UserAddress="Balasore",UserName="Kiran6",
                       EmailId="kiranmayapuhan6@gmail.com",Password="22bb33@9",Role="Job Seeker"},

                new(){ UserId=2,UserFirstName="Kartik",UserLastName="Mane",UserDOB=new DateTime(2000,04,10),
                       Gender="M",UserPhoneNumber=1111111331,UserAddress="Mhow",UserName="KartikM",
                       EmailId="kartikmane@gmail.com",Password="23as33@9",Role="Job Seeker"},

                new(){ UserId=3,UserFirstName="Smruti",UserMiddleName="Ranjan",UserLastName="Parida",UserDOB=new DateTime(2007,11,05),
                       Gender="M",UserPhoneNumber=111164676111,UserAddress="Cuttack",UserName="Smr66",
                       EmailId="smr66@gmail.com",Password="smrbb33@9",Role="Employer"},
            };
        }

        public static List<User> EmptyUserList()
        {
            return new List<User>();
        }

        public static User User()
        {
            return new User()
            {
                UserId = 4,
                UserFirstName = "Smruti",
                UserLastName = "Parida",
                UserDOB = new DateTime(2007, 11, 05),
                Gender = "F",
                UserPhoneNumber = 111164676111,
                UserAddress = "Cuttack",
                UserName = "Smr766",
                EmailId = "smr766@gmail.com",
                Password = "smrbb373@9",
                Role = "Job Seeker"
            };
        }
        public static User EmptyUser()
        {
            return null;
        }
        public static User NewUser()
        {
            return new User()
            {
                UserId = 4,
                UserFirstName = "Satyam",
                UserLastName = "Parida",
                UserDOB = new DateTime(2007, 11, 05),
                Gender = "M",
                UserPhoneNumber = 111164676111,
                UserAddress = "Bokaro",
                UserName = "Smr766",
                EmailId = "smr766@gmail.com",
                Password = "smrbb373@9",
                Role = "Job Seeker"
            };
        }
        public static string UserName()
        {
            return "kiran6";
        }
        public static string EmptyUserName()
        {
            return null;
        }
        public static string PasswordChanged()
        {
            return "Success";

        }
        public static string NullPassword()
        {
            return null;

        }
        public static UserLoginDetails UserLoginDetails()
        {
            return new UserLoginDetails()
            {

                UserName = "Smr66",
                Password = "smrbb33@9"
            };
        }
        public static UserLoginDetails EmptyUserLoginDetails()
        {
            return new UserLoginDetails();
        }

        public static string Token()
        {
            return "Thisisatoken";
        }
    }
}
