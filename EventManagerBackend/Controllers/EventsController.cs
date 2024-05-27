using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EventManagerBackend.Models;
using EventManagerBackend.Data;

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
        public async Task<ActionResult<EventCreateModel>> PostEventModel(EventCreateModel eventCreateModel)
        {

            var eventModel = new EventModel
            {
                Name = eventCreateModel.Name,
                Description = eventCreateModel.Description,
                Place = eventCreateModel.Place,
                StartDateTime = eventCreateModel.StartDateTime,
                EventType = eventCreateModel.EventType
            };

            _context.Events.Add(eventModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventModel", new { id = eventModel.Id }, eventModel);
        }
    }
}