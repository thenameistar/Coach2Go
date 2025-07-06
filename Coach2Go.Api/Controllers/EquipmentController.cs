using Coach2Go.Api.Data;
using Coach2Go.Api.Models;
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

        
        // GET: api/GymEquipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymEquipment>>> GetGymEquipment()
        {
            return await _context.GymEquipment.ToListAsync();
        }

        // GET: api/GymEquipment/1
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
        
    }
}