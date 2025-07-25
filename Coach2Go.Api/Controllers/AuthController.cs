using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Coach2Go.Api.Data;
using Coach2Go.Api.Data.Generators;
using Coach2Go.Api.Models;
using Coach2Go.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ApplicationDbContext _context;

    public AuthController(IConfiguration config, ApplicationDbContext context)
    {
        _config = config;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        if (userExists != null)
            return BadRequest("User already exists");

        // 1. Create user first (without WorkoutPlanId yet)
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            Goal = request.Goal,
            Type = request.Type,
            Experience = request.Experience
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(); // Save to get user.Id

        // 2. Generate plan and link to user
        var generatedPlan = PlanGenerator.GeneratePlan(request.Goal, request.Type, request.Experience);
        generatedPlan.UserId = user.Id;

        _context.WorkoutPlans.Add(generatedPlan);
        await _context.SaveChangesAsync();

        // 3. Update user with plan ID
        user.WorkoutPlanId = generatedPlan.Id;
        await _context.SaveChangesAsync();

        // 4. Return token + user DTO
        var token = GenerateJwtToken(user);
        return Ok(new
        {
            token,
            user = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
                // Optional: include Goal/Type/Experience if needed on frontend
            }
        });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new
        {
            token,
            user = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            }
        });
    }

    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _config.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        var securityKey = new SymmetricSecurityKey(key);
        var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
public class RegisterRequest
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;


    public string Goal { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty;
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; 
}