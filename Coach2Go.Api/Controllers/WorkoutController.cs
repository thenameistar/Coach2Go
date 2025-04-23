using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Data;

namespace Coach2Go.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyWorkout()
        {
            var workout = await _context.WorkoutPlans
                .Include(p => p.Sessions)
                    .ThenInclude(s => s.Exercises)
                .FirstOrDefaultAsync();

            if (workout == null)
                return NotFound();

            return Ok(workout);
        }
    }
}