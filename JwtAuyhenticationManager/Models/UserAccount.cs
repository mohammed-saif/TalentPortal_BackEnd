namespace JwtAuyhenticationManager.Models
{
    public class UserAccount
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserMiddleName { get; set; }

        public string UserLastName { get; set; }

        public DateTime UserDOB { get; set; }

        public string Gender { get; set; }


        public long UserPhoneNumber { get; set; }
       
        public string UserAddress { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
