using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EventManagerBackend.Models;
using EventManagerBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EmDbContext _context;

        public EventsController(EmDbContext context)
        {
            _context = context;
        }


        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventModel>> GetEventModel(int id)
        {
            var eventModel = await _context.Events.FindAsync(id);

            if (eventModel == null)
            {
                return NotFound();
            }

            return eventModel;
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<EventCreateModel>> PostEventModel([FromForm] EventCreateModel eventCreateModel)
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(eventCreateModel.Image.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)eventCreateModel.Image.Length);
            }


            var eventModel = new EventModel
            {
                Name = eventCreateModel.Name,
                Description = eventCreateModel.Description,
                Place = eventCreateModel.Place,
                StartDateTime = eventCreateModel.StartDateTime,
                EventType = eventCreateModel.EventType,
                Image = imageData
            };

            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventModel", new { id = eventModel.Id }, eventModel);
        }
    }
}