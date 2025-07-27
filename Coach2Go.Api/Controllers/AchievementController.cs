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
[Route("api/[controller]")]
public class AchievementsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AchievementsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<AchievementDto>>> GetAchievements(int userId)
    {
        var achievements = await _context.Achievements
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.AchievedOn)
            .Select(a => new AchievementDto
            {
                Title = a.Title,
                Description = a.Description,
                AchievedOn = a.AchievedOn
            })
            .ToListAsync();

        return Ok(achievements);
    }
}