using ClubSportif.BLL.Interfaces;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournoisController : ControllerBase
    {
        private readonly ITournoiService _tournoiService;

        public TournoisController(ITournoiService tournoiService)
        {
            _tournoiService = tournoiService;
        }

        // GET: api/Tournois
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournoi>>> GetTournois()
        {
            var tournois = await _tournoiService.GetAllTournoisAsync();
            return Ok(tournois);
        }

        // GET: api/Tournois/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournoi>> GetTournoi(int id)
        {
            var tournoi = await _tournoiService.GetTournoiByIdAsync(id);
            if (tournoi == null)
            {
                return NotFound();
            }
            return Ok(tournoi);
        }

        // POST: api/Tournois
        [HttpPost]
        public async Task<ActionResult<Tournoi>> PostTournoi([FromBody] Tournoi tournoi)
        {
            try
            {
                var createdTournoi = await _tournoiService.CreateTournoiAsync(tournoi);
                return CreatedAtAction(nameof(GetTournoi), new { id = createdTournoi.TournoiID }, createdTournoi);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Tournois/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournoi(int id, [FromBody] Tournoi tournoi)
        {
            if (id != tournoi.TournoiID)
            {
                return BadRequest();
            }

            await _tournoiService.UpdateTournoiAsync(tournoi);
            return NoContent();
        }

        // DELETE: api/Tournois/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournoi(int id)
        {
            await _tournoiService.DeleteTournoiAsync(id);
            return NoContent();
        }
    }
}