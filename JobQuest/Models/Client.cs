using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobQuest.Models
{
    public class Client
    {
        [Key]
        public string ApplicationUserId { get; set; }

        // Navigation property
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string? BillingInformation { get; set; }  // Nullable property
        public virtual ICollection<Job> Jobs { get; set; } = new List<Job>(); 
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
