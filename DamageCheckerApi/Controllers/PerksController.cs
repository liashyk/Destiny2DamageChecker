using Destiny2DataLibrary.DataAccess;
using Destiny2DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace DamageCheckerApi.Controllers
{
    [Route("api/perks")]
    [ApiController]
    public class PerksController : ControllerBase
    {
        Destiny2DataContext _context;
        public PerksController(Destiny2DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Perk>> GetPerks()
        {
            var perks = await Task.Run(() =>
            {
                return _context.Perks;
            });
            return perks;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perk>> GetPerks(int id)
        {
            Perk perk = await Task.Run(() =>
            {
                return _context.Perks.Where(p => p.Id == id).Single();
            });
            return perk;
        }
    }
}
