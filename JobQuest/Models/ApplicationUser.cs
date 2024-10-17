using JobQuest.Authorization;
using Microsoft.AspNetCore.Identity;

namespace JobQuest.Models
{
    public class ApplicationUser:IdentityUser
    {
        // add common attributes
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Client Client { get; set; }
        public Freelancer Freelancer { get; set; }
        public Admin Admin { get; set; }

    }
}
