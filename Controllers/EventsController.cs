using embackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace embackend.Controllers
{
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        [Route("/api/create")]
        public async Task<IActionResult> CreateEvent([FromBody] Event ev)
        {
            if (ev == null)
            {
                return BadRequest("Event data is null.");
            }

            try
            {
                using var db = new EventContext();
                db.Add(ev);
                await db.SaveChangesAsync();
                var response = new EventCreatedResponse(ev, "Event created successfully.");
                return CreatedAtAction(nameof(CreateEvent), new { name = ev.name }, response);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "An error occurred while saving the event.", error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred at server.", error = ex.Message });
            }
        }
        [HttpGet]
        [Route("/api/list")]
        public async Task<IActionResult> GetEvents()
        {
            try
            {
                using var db = new EventContext();
                var events = await db.eventTable.ToListAsync();

                if (events == null || events.Count == 0)
                {
                    return NotFound(new { message = "No events found." });
                }

                return Ok(events);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
            }
        }
    }
}
