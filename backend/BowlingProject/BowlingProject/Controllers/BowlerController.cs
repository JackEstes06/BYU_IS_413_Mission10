using BowlingProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private BowlerDbContext _context;
        public BowlerController(BowlerDbContext temp)
        {
            _context = temp;
        }

        [HttpGet(Name = "GetBowler")]
        public IEnumerable<Bowler> Get()
        {
            string? favBowler = Request.Cookies["FavoriteBowler"];
            Console.WriteLine($"-----COOKIE-----\n{favBowler}");
            
            HttpContext.Response.Cookies.Append(
                "FavoriteBowler",
                "John A Kennedy", 
                new CookieOptions{
                    // Can only be seen by the server
                    HttpOnly = true,
                    // Only transmitted over HTTPS - needed once deployed, dev it depends
                    Secure = true,
                    // Whether other site's cookies are allowed - might need to lax for cors or csp during dev
                    SameSite = SameSiteMode.Strict,
                    // Depends on if session cookie and has its use cases
                    Expires = DateTime.Now.AddMinutes(1),
                });
            
            IEnumerable<Bowler> bowlerList = _context.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamName == "Marlins" || x.Team.TeamName == "Sharks")
                .ToList();
            return bowlerList;
        }
    }
}
