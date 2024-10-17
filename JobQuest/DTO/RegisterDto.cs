namespace JobQuest.DTO
{
    public enum UserType
    {
        Client,
        Freelancer
    }

    public class UserRegistrationDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public UserType UserType { get; set; } // New property to specify user type
    }
}
