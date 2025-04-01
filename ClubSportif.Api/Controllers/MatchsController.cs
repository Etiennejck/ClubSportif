using ClubSportif.BLL.Interfaces;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchsController : ControllerBase
    {
        private readonly IMatchService _matchs;

        public MatchsController(IMatchService matchService)
        {
            _matchs = matchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatchs()
        {
            var matchs = await _matchs.GetAllMatchesAsync();
            return Ok(matchs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetById(int id)
        {
            var match = await _matchs.GetMatchByIdAsync(id);
            if (match == null)
                return NotFound();

            return Ok(match);
        }

        [HttpPost]
        public async Task<ActionResult<Match>> Create(Match match)
        {
           try
            {
                var createdMatch = await _matchs.CreateMatchAsync(match);
                return CreatedAtAction(nameof(GetById), new { id = createdMatch.MatchID }, createdMatch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Match>> Update(int id, Match match)
        {
            if (id != match.MatchID)
                return BadRequest("ID mismatch");

            await _matchs.UpdateMatchAsync(match);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var match = await _matchs.GetMatchByIdAsync(id);
            if (match == null)
                return NotFound();

            await _matchs.DeleteMatchAsync(id);
            return NoContent();
        }
    }


}