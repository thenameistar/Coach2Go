using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Data;
using Coach2Go.Shared.Dtos;

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

        [HttpGet("daily/{userId}")]
        public async Task<IActionResult> GetDailyWorkout(int userId)
        {
            var user = await _context.Users
                .Include(u => u.WorkoutPlan)
                    .ThenInclude(p => p!.Sessions)
                        .ThenInclude(s => s.Exercises)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.WorkoutPlan == null)
                return NotFound("User or workout plan not found");

            var workoutPlan = user.WorkoutPlan;

            var mappedDto = new WorkoutPlanDto
            {
                Id = workoutPlan.Id,
                Goal = workoutPlan.Goal,
                Type = workoutPlan.Type,
                Experience = workoutPlan.Experience,
                Duration = workoutPlan.Duration,
                Intensity = workoutPlan.Intensity,
                Sessions = workoutPlan.Sessions.Select(s => new WorkoutSessionDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    ImagePath = s.ImagePath,
                    Exercises = s.Exercises.Select(e => new ExerciseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Details = e.Details,
                        ImagePath = e.ImagePath
                    }).ToList()
                }).ToList()
            };

            return Ok(mappedDto);
        }
        [HttpGet("plan/{id}")]
        public async Task<IActionResult> GetPlanById(int id)
        {
            var plan = await _context.WorkoutPlans
            .Include(p => p.Sessions)
            .FirstOrDefaultAsync(p => p.Id == id);

            if (plan == null) return NotFound();
            var dto = new WorkoutPlanDto
            {
                Id = plan.Id,
                Goal = plan.Goal,
                Type = plan.Type,
                Experience = plan.Experience,
                Duration = plan.Duration,
                Intensity = plan.Intensity,
                Sessions = plan.Sessions.Select(s => new WorkoutSessionDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Week = s.Week,
                    Day = s.Day,
                    ImagePath = s.ImagePath,
                    Duration = s.Duration
                }).ToList()
            };

            return Ok(dto);
        }
        [HttpGet("sessions-by-category/{category}")]
        public async Task<IActionResult> GetSessionsByCategory(string category)
        {
            var sessions = await _context.WorkoutSessions
            .Include(s => s.Exercises)
            .Include(s => s.WorkoutPlan)
            .Where(s => s.Category == category)
            .Select(s => new WorkoutSessionDto
            {
                Id = s.Id,
                Title = s.Title,
                Week = s.Week,
                Day = s.Day,
                Category = s.Category,
                ImagePath = s.ImagePath,
                Duration = s.Duration,
                Exercises = s.Exercises.Select(e => new ExerciseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Details = e.Details,
                    ImagePath = e.ImagePath
                }).ToList()
            }).ToListAsync();

            return Ok(sessions);
        }

        [HttpPost("assign-plan")]
        public async Task<IActionResult> AssignPlan([FromBody] UserOnboardingDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            user.Goal = dto.Goal;
            user.Type = dto.Type;
            user.Experience = dto.Experience;
            
            var matchingPlan = await _context.WorkoutPlans.FirstOrDefaultAsync(p =>
                p.Goal == dto.Goal &&
                p.Type == dto.Type &&
                p.Experience == dto.Experience
            );

            if (matchingPlan == null) return NotFound("No matching plan");

            user.WorkoutPlanId =matchingPlan.Id; 

            await _context.SaveChangesAsync();

            return Ok(new { message = "Workout plan assigned", PlanId = matchingPlan.Id });
        }
    }

}
