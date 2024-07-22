using embackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace embackend.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("/api/login")]
        public async Task<IActionResult> LoginUser(User user)
        {
            try
            {
                using var db = new RegisterContext();
                var existingUser = await db.users.FirstOrDefaultAsync(u => u.email == user.email);
                if (existingUser != null)
                {
                    bool passwordsMatch = existingUser.password == user.password;
                    if (passwordsMatch == true)
                    {
                        return StatusCode(200, new { isloggedin = passwordsMatch, message = "User successfully loggedIn" });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "Invalid email or password" });
                    }
                }
                else
                {
                    return StatusCode(404, new { message = "Invalid email or password" });
                }
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
    }
}