using Coach2Go.Api.Data;
using Coach2Go.Api.Models;
using Coach2Go.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coach2Go.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GymEquipmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GymEquipmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymEquipment>>> GetGymEquipment()
        {
            return await _context.GymEquipment.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymEquipment>> GetGymEquipment(int id)
        {
            var equipment = await _context.GymEquipment.FindAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return equipment;
        }

        
        [HttpGet("gym/{gymName}")]
        public async Task<ActionResult<List<GymEquipmentDto>>> GetEquipmentByGym(string gymName)
        {
            var equipment = await _context.GymEquipment
                .Where(e => e.GymName == gymName)
                .Select(e => new GymEquipmentDto
                {
                    EquipmentName = e.EquipmentName,
                    ImageUrl = e.ImageUrl
                })
                .ToListAsync();

            return equipment;
        }
    }
}