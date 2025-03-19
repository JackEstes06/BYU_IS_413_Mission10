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
            IEnumerable<Bowler> bowlerList = _context.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamName == "Marlins" || x.Team.TeamName == "Sharks")
                .ToList();
            return bowlerList;
        }
    }
}
