using embackend.Models;
using Microsoft.AspNetCore.Mvc;
namespace embackend.Controllers
{
    [ApiController]
    public class EventsController : Controller
    {
        [HttpPost]
        [Route("/api/create")]
        public  IActionResult  CreateEvent( [FromBody] Event ev)
        {
            using var db = new EventContext();
            db.Add(ev);
            db.SaveChangesAsync();
            return Created();
        }
    }
}
