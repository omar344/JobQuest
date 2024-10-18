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

namespace JobQuest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly PlatformDataDbContext dbContext;
        private readonly IClientRepository ClientRepo;
        private readonly RoleManager<IdentityRole> roleManager;

        // Constructor
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config,
            PlatformDataDbContext dbContext, IClientRepository clientRepo, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.config = config;
            this.dbContext = dbContext;
            this.ClientRepo = clientRepo;
            this.roleManager = roleManager;
        }

        // Register method
        [HttpPost("Register")]
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

                    return Ok("User registered successfully.");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return BadRequest(ModelState);
        }

        // Login method
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto userFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDb = await userManager.FindByNameAsync(userFromRequest.UserName);

                if (userFromDb != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userFromDb, userFromRequest.Password);

                    if (found)
                    {
                        var userRoles = await userManager.GetRolesAsync(userFromDb);
                        var userClaims = new List<Claim>
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                            new Claim(ClaimTypes.Name, userFromDb.UserName)
                        };

                        // Add roles to claims
                        userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecretKey"]));
                        var signingCred = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                        JwtSecurityToken myToken = new(
                            issuer: config["JWT:IssuerIP"],
                            audience: config["JWT:AudienceIP"],
                            expires: DateTime.Now.AddHours(1),
                            claims: userClaims,
                            signingCredentials: signingCred
                        );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(myToken),
                            expiration = myToken.ValidTo
                        });
                    }
                    else
                    {
                        return Unauthorized("Invalid password.");
                    }
                }
                else
                {
                    return Unauthorized("User not found.");
                }
            }

            return BadRequest(ModelState);
        }

        // Add Role method
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole([FromBody] string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if (result.Succeeded)
                {
                    return Ok(new { message = "Role Added Successfully" });
                }
                return BadRequest(result.Errors);
            }
            return BadRequest("Role already Exists");
        }

        // Assign Role method
        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRole model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var result = await userManager.AddToRoleAsync(user, model.Role);
            if (result.Succeeded)
            {
                return Ok(new { message = "Role assigned successfully" });
            }

            return BadRequest(result.Errors);
        }
    }
}
