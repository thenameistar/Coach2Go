using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coach2Go.Api.Data;
using Coach2Go.Api.Data.Generators;
using Coach2Go.Shared.Dtos;
using Coach2Go.Api.Services; 
using System.Text.Json;  

namespace Coach2Go.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WorkoutController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IAiService _aiService;

        public WorkoutController(ApplicationDbContext context, IAiService aiService)
        {
            _context = context;
            _aiService = aiService;
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
                    Duration = s.Duration,
                    Category = s.Category,
                    Day = s.Day,
                    Week = s.Week,
                    IsCompleted = s.IsCompleted,
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

        
        [HttpPost("assign-plan")]
        public async Task<IActionResult> AssignPlan([FromBody] UserOnboardingDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null) return NotFound("User not found");

            user.Goal = dto.Goal;
            user.Type = dto.Type;
            user.Experience = dto.Experience;

            var generatedPlan = PlanGenerator.GeneratePlan(dto.Goal, dto.Type, dto.Experience);
            _context.WorkoutPlans.Add(generatedPlan);
            await _context.SaveChangesAsync();

            user.WorkoutPlanId = generatedPlan.Id;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Workout plan assigned", PlanId = generatedPlan.Id });
        }

       
        [HttpGet("plan/{id}")]
        public async Task<IActionResult> GetPlan(int id)
        {
            var plan = await _context.WorkoutPlans
                .Include(p => p.Sessions)
                .ThenInclude(s => s.Exercises)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plan == null)
                return NotFound("Plan not found");

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
                    ImagePath = s.ImagePath,
                    Duration = s.Duration,
                    Category = s.Category,
                    Day = s.Day,
                    Week = s.Week,
                    IsCompleted = s.IsCompleted,
                    Exercises = s.Exercises.Select(e => new ExerciseDto
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Details = e.Details,
                        ImagePath = e.ImagePath
                    }).ToList()
                }).ToList()
            };

            return Ok(dto);
        }
        
        
        [HttpPost("session/{id}/complete")]
        public async Task<IActionResult> MarkSessionComplete(int id, [FromQuery] int userId)
        {
            var session = await _context.WorkoutSessions.FindAsync(id);
            if (session == null)
                return NotFound("Workout session not found");
            
            session.IsCompleted = true;
            session.CompletedDate = DateTime.UtcNow;
            session.UserId = userId;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Workout session marked as completed" });
        }

        [HttpPost("static-suggestions")]
        public IActionResult GetStaticWorkouts([FromBody] WorkoutPreferencesDto prefs)
        {
            var results = _context.WorkoutSessions
                .Where(w => w.Type == prefs.Type && w.Level == "Beginner" && w.Duration == prefs.Time)
                .Take(6)
                .Select(w => new WorkoutSessionDto
                {
                    Title = w.Title,
                    Duration = w.Duration,
                    ImagePath = w.ImagePath
                })
                .ToList();

            return Ok(results);
        }

        [HttpPost("generate-ai")]
        public async Task<IActionResult> GenerateWithAI([FromBody] WorkoutPreferencesDto prefs)
        {
            var prompt = $"""
                You are a fitness AI assistant. Generate 5 beginner-level workout sessions based on:
                - Type: {prefs.Type}
                - Goal: {prefs.Goal}
                - Time: {prefs.Time} minutes

                For each workout, provide:
                - Title
                - Duration in minutes
                - Level (Beginner)
                - 1–2 sentence description
                - 4–5 exercises, each with a name and either reps or time.

                Format your response as a JSON array of workout objects.
            """;

            var response = await _aiService.GenerateWorkouts(prompt);
            var workouts = JsonSerializer.Deserialize<List<WorkoutSessionDto>>(response);
            
            return Ok(workouts);
        }
    }
}