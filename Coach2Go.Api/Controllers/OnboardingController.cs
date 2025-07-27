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
[Route("api/onboarding")]
public class OnboardingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OnboardingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("complete")]
    public async Task<IActionResult> CompleteOnboarding([FromBody] UserOnboardingDto dto)
    {
        
        var plan = PlanGenerator.GeneratePlan(dto.Goal, dto.Type, dto.Experience);

        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int parsedUserId))
        {
            plan.UserId = parsedUserId;
        }

       
        _context.WorkoutPlans.Add(plan);
        await _context.SaveChangesAsync();

        return Ok(plan.Id); 
    }
}

public class OnboardingDto
{
}