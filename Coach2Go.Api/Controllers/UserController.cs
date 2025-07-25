using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Coach2Go.Api.Data;
using Coach2Go.Api.Data.Generators;
using Coach2Go.Api.Models;
using System.Security.Claims;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpPost("onboarding")]
    public async Task<IActionResult> SubmitOnboarding([FromBody] OnboardingRequest req)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var user = await _context.Users.FindAsync(userId);

        if (user == null) return NotFound();

        var plan = PlanGenerator.GeneratePlan(req.Goal, req.Type, req.Experience);
        plan.UserId = user.Id;
        _context.WorkoutPlans.Add(plan);
        await _context.SaveChangesAsync();

        user.Goal = req.Goal;
        user.Type = req.Type;
        user.Experience = req.Experience;
        user.WorkoutPlanId = plan.Id;

        await _context.SaveChangesAsync();

        return Ok();
    }
}

public class OnboardingRequest
{
    public string Goal { get; set; } = "";
    public string Type { get; set; } = "";
    public string Experience { get; set; } = "";
}