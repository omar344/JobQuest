using JobQuest.DTO;
using JobQuest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using JobQuest.Data;
using JobQuest.Interface;
using JobQuest.Authorization;

namespace JobQuest.Controllers
{
    [ApiController] // Add this attribute to your controller
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly PlatformDataDbContext dbContext;
        private readonly IClientRepository ClientRepo;
        private readonly PermissionService _permissionService;

        // Correct constructor syntax
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config,
            PlatformDataDbContext dbContext, IClientRepository clientRepo, PermissionService permissionService)
        {
            this.userManager = userManager;
            this.config = config;
            this.dbContext = dbContext;
            this.ClientRepo = clientRepo; // Assign the injected repository
            _permissionService = permissionService;
        }

        [HttpPost("Register")] // POST api/Account/Register
        public async Task<IActionResult> Register(UserRegistrationDTO registrationDTO)
        {
            if (ModelState.IsValid)
            {
                // Save in the database
                var user = new ApplicationUser
                {
                    UserName = registrationDTO.UserName,
                    Email = registrationDTO.Email,
                    FullName = registrationDTO.FullName,
                    Address = registrationDTO.Address,
                    DateOfBirth = registrationDTO.DateOfBirth
                };

                IdentityResult result = await userManager.CreateAsync(user, registrationDTO.Password);

                if (result.Succeeded)
                {
                    if (registrationDTO.UserType == UserType.Client)
                    {
                        // Assign permissions for Client type
                        await _permissionService.AssignPermissionsToUser(user, new List<string> { "CanViewJobs" });

                        return Ok("User registered and permissions assigned successfully.");
                    }
                    return BadRequest("Unsupported user type");
                }

                // Handle errors from IdentityResult
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")] // POST api/Account/Login
        public async Task<IActionResult> Login(LoginDto userFromRequest)
        {
            if (ModelState.IsValid)
            {
                // Check if the user exists
                ApplicationUser userFromDb = await userManager.FindByNameAsync(userFromRequest.UserName);

                if (userFromDb != null)
                {
                    // Verify the password
                    bool found = await userManager.CheckPasswordAsync(userFromDb, userFromRequest.Password);

                    if (found)
                    {
                        // Generate the JWT token with roles and permissions
                        var userClaims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                            new Claim(ClaimTypes.Name, userFromDb.UserName)
                        };

                        // Retrieve permissions for the user
                        var userPermissions = await GetUserPermissionsAsync(userFromDb);
                        foreach (var permission in userPermissions)
                        {
                            userClaims.Add(new Claim("Permission", permission));
                        }

                        // Create the security key and credentials
                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                        var signingCred = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                        // Create the token
                        JwtSecurityToken myToken = new(
                            issuer: config["JWT:IssuerIP"],
                            audience: config["JWT:AudienceIP"],
                            expires: DateTime.Now.AddHours(1),
                            claims: userClaims,
                            signingCredentials: signingCred
                        );

                        // Return the token and expiration time
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration = myToken.ValidTo
                        });
                    }
                    else
                    {
                        // Password is incorrect
                        return Unauthorized("Invalid password.");
                    }
                }
                else
                {
                    // User not found
                    return Unauthorized("User not found.");
                }
            }

            // If the model state is invalid, return bad request
            return BadRequest(ModelState);
        }

        // Helper method to retrieve user permissions from the database
        private async Task<List<string>> GetUserPermissionsAsync(ApplicationUser user)
        {
            var permissions = new List<string>();

            // Get permissions from roles
            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                var rolePermissions = await dbContext.RolePermissions
                    .Where(rp => rp.Role.Name == role)
                    .Select(rp => rp.Permission.Name)
                    .ToListAsync();

                permissions.AddRange(rolePermissions);
            }

            // Get direct user permissions
            var userPermissions = await dbContext.UserPermissions
                .Where(up => up.UserId == user.Id)
                .Select(up => up.Permission.Name)
                .ToListAsync();

            permissions.AddRange(userPermissions);

            return permissions.Distinct().ToList(); // Remove duplicates
        }
    }
}
