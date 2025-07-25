using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Data;
using Coach2Go.Shared.Dtos;

namespace Coach2Go.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProgressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProgressController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("weekly/{userId}")]
        public async Task<IActionResult> GetWeeklyProgress(int userId)
        {
            var today = DateTime.UtcNow.Date;
            var monday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            var sunday = monday.AddDays(6);

            var count = await _context.WorkoutSessions
                .CountAsync(w =>
                    w.IsCompleted &&
                    w.CompletedDate >= monday &&
                    w.CompletedDate <= sunday &&
                    w.UserId == userId);

            return Ok(count);
        }

        [HttpGet("activity/{userId}")]
        public async Task<IActionResult> GetActivityData(int userId)
        {
            var today = DateTime.UtcNow.Date;
            var monday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            
            var data = await _context.WorkoutSessions
                .Where(s => s.IsCompleted && s.UserId == userId && s.CompletedDate >= monday)
                .GroupBy(s => s.CompletedDate!.Value.DayOfWeek)
                .ToDictionaryAsync(
                    g => g.Key.ToString().Substring(0, 3),
                    g => g.Count()
                );
            
            var fullWeek = Enum.GetValues<DayOfWeek>().Take(5)
                .Select(d => data.TryGetValue(d.ToString().Substring(0, 3), out var count) ? count : 0)
                .ToArray();
            return Ok(fullWeek);
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetWorkoutHistory(int userId)
        {
            var history = await _context.WorkoutSessions
                .Where(s => s.IsCompleted && s.UserId == userId)
                .Select(s => new WorkoutProgressDto
                {
                    SessionTitle = s.Title,
                    Sets = s.Exercises.Count,
                    Date = s.CompletedDate!.Value.ToUniversalTime()
                })
                .OrderByDescending(h => h.Date)
                .Take(5)
                .ToListAsync();
            
            return Ok(history);
        }
    }
}