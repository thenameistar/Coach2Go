using Microsoft.AspNetCore.Mvc;
using Coach2Go.Api.Data;
using Coach2Go.Api.Models;
using Coach2Go.Shared.Dtos;

namespace Coach2Go.Api.Controllers
{
    [ApiController]
    [Route("api/diary")]
    public class DiaryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DiaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("today/{userId}")]
        public ActionResult<DiaryEntryDto> GetTodayEntry(int userId)
        {
            var today = DateTime.Today;
            var entry = _context.DiaryEntries.FirstOrDefault(e => e.UserId == userId && e.Date == today);

            if (entry == null) return Ok(null);

            return Ok(new DiaryEntryDto
            {
                UserId = entry.UserId,
                Date = entry.Date,
                Goals = entry.Goals ?? new List<string>(),
                Note = entry.Note,
                Mood = entry.Mood,
                StreakPercent = entry.StreakPercent
            });
        }

        [HttpPost("today")]
        public async Task<IActionResult> SaveTodayEntry([FromBody] DiaryEntryDto dto)
        {
            var today = DateTime.UtcNow.Date;
            var existing = _context.DiaryEntries.FirstOrDefault(e => e.UserId == dto.UserId && e.Date == today);

            if (existing != null)
            {
                existing.Goals = dto.Goals;
                existing.Note = dto.Note;
                existing.Mood = dto.Mood;
                existing.StreakPercent = dto.StreakPercent;
            }
            else
            {
                var entry = new DiaryEntry
                {
                    UserId = dto.UserId,
                    Date = today,
                    Goals = dto.Goals,
                    Note = dto.Note,
                    Mood = dto.Mood,
                    StreakPercent = dto.StreakPercent
                };

                _context.DiaryEntries.Add(entry);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("all/{userId}")]
        public ActionResult<List<DiaryEntryDto>> GetAllEntries(int userId)
        {
            var entries = _context.DiaryEntries
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.Date)
                .ToList();

            var dtos = entries.Select(e => new DiaryEntryDto
            {
                UserId = e.UserId,
                Date = e.Date,
                Goals = e.Goals ?? new List<string>(),
                Note = e.Note,
                Mood = e.Mood,
                StreakPercent = e.StreakPercent
            }).ToList();

            return Ok(dtos);
        }

    }
}