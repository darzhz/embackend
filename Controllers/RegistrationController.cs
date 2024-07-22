using embackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace embackend.Controllers{
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        [HttpPost]
        [Route("/api/registration")]
        public async Task<IActionResult> RegisterUser([FromBody] User us){
            if(us == null)
            {
                return BadRequest("Registration Data is Null");
            }
            try {
                using var db = new RegisterContext();
                db.users.Add(us);
                await db.SaveChangesAsync();
                var responce = new RegistrationResponce(us,"User registered successfully/");
                return CreatedAtAction(nameof(RegisterUser),new {name= us.fname},responce);
            } catch (DbUpdateException ex){
                return StatusCode(500, new { message = "An error occurred while saving the event.", error = ex.InnerException != null?ex.InnerException.Message:ex.Message });
            }
             catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred at server.", error = ex.Message });
            }
        }
    }
}