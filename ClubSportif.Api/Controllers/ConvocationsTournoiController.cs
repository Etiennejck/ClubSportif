using ClubSportif.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClubSportif.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocationsTournoiController : ControllerBase
    {
        private readonly IConvocationTournoiService convocationTournoi;

        public ConvocationsTournoiController(IConvocationTournoiService convocationTournoiService)
        {
            convocationTournoi = convocationTournoiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConvocationTournoi>>> GetConvocations()
        {
            var convocations = await convocationTournoi.GetAllConvocationTournoisAsync();
            return Ok(convocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConvocationTournoi>> GetById(int id)
        {
            var convocation = await convocationTournoi.GetConvocationTournoiByIdAsync(id);
            if (convocation == null)
                return NotFound();
            return Ok(convocation);
        }

        [HttpPost]
        public async Task<ActionResult<ConvocationTournoi>> Create(ConvocationTournoi convocation)
        {
            try
            {
                var createdConvocation = await convocationTournoi.CreateConvocationTournoiAsync(convocation);
                return CreatedAtAction(nameof(GetById), new { id = createdConvocation.ConvocationTournoiID }, createdConvocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConvocationTournoi>> Update(int id, ConvocationTournoi convocation)
        {
            if (id != convocation.ConvocationTournoiID)
                return BadRequest("ID mismatch");
            await convocationTournoi.UpdateConvocationTournoiAsync(convocation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await convocationTournoi.DeleteConvocationTournoiAsync(id);
            return NoContent();
        }

    }
}
