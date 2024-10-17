
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace JobQuest.Authorization
{

    public class RolePermission
    {
        [Key]
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }

}
