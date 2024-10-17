using JobQuest.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace JobQuest.Authorization
{
    public class UserPermission
    {
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
