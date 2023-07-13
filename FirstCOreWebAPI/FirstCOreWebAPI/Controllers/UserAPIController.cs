using FirstCOreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCOreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly PoojaSchoolMgmt326Context context;

        public UserAPIController(PoojaSchoolMgmt326Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }
            var user = await context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            } 
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(User userData)
        {
            if(userData == null || userData.Id == 0)
            {
                return BadRequest();
            }
            var user = await context.Users.FindAsync(userData.Id);
            if (user == null)
            {
                return NotFound();
            }
            user.UserName = userData.UserName;
            user.Email = userData.Email;
            user.Password = userData.Password;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
