using JobQuest.DTO;
using JobQuest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobQuest.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> UserManager,IConfiguration config)
        {
            userManager = UserManager;
            this.config = config;
        }

        [HttpPost("Register")] // POST api/Account/Register
        public async Task<IActionResult> Register(RegisterDto UserFormRequest)
        {
            if (ModelState.IsValid)
            {
                // Save in the database
                ApplicationUser user = new()
                {
                    UserName = UserFormRequest.UserName,
                    Email = UserFormRequest.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, UserFormRequest.Password);

                if (result.Succeeded)
                {
                    return Ok("User created successfully.");
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
                        // Generate the JWT token
                        List<Claim> userClaims = new()
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                            new Claim(ClaimTypes.Name, userFromDb.UserName)
                        };

                        // Add roles as claims
                        var userRoles = await userManager.GetRolesAsync(userFromDb);
                        foreach (var roleName in userRoles)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, roleName));
                        }

                        // Create the security key and credentials
                        var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT: SecritKey"]));
                        var signingCred = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

                        // Create the token
                        JwtSecurityToken myToken = new(
                            issuer: config["JWT: IssuerIP"],
                            audience: config["JWT: AudienceIP"],
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
    }
}
