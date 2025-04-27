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

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyWorkout()
        {
            var workout = await _context.WorkoutPlans
                .Include(p => p.Sessions)
                    .ThenInclude(s => s.Exercises)
                .FirstOrDefaultAsync(w => w.Id == 1);

            if (workout == null) return NotFound();

            var mappedDto = new WorkoutPlanDto
            {
                Id = workout.Id,
                Goal = workout.Goal,
                Type = workout.Type,
                Experience = workout.Experience,
                Duration = workout.Duration,
                Intensity = workout.Intensity,
                Sessions = workout.Sessions.Select(s => new WorkoutSessionDto
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
    }

}