using ClubSportif.BLL.Interfaces;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetClubs()
        {
            var clubs = await _clubService.GetAllClubsAsync();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetClub(int id)
        {
            var club = await _clubService.GetClubByIdAsync(id);
            if (club == null)
                return NotFound();
            return Ok(club);
        }

        [HttpPost]
        public async Task<ActionResult<Club>> Create([FromBody]Club club)
        {
            try
            {
                var createdClub = await _clubService.CreateClubAsync(club);
                return CreatedAtAction(nameof(GetClub), new { id = createdClub.ClubID }, createdClub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Club>> Update(int id,[FromBody] Club club)
        {
            if (id != club.ClubID)
            {
                return BadRequest();
            }
            
            await _clubService.UpdateClubAsync(club);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clubService.DeleteClubAsync(id);
            return NoContent();
        }

    }
}
