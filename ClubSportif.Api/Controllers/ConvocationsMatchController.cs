using ClubSportif.BLL.Interfaces;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvocationsMatchController : ControllerBase
    {
        private readonly IConvocationMatchService _convocations;

        public ConvocationsMatchController(IConvocationMatchService convocationMatchService)
        {
            _convocations = convocationMatchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConvocationMatch>>> GetConvocations()
        {
            var convocations = await _convocations.GetAllConvocationMatchesAsync();
            return Ok(convocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConvocationMatch>> GetById(int id)
        {
            var convocation = await _convocations.GetConvocationMatchByIdAsync(id);
            if (convocation == null)
                return NotFound();

            return Ok(convocation);
        }

        [HttpPost]
        public async Task<ActionResult<ConvocationMatch>> Create(ConvocationMatch convocation)
        {
            try
            {
                var createdConvocation = await _convocations.CreateConvocationMatchAsync(convocation);
                return CreatedAtAction(nameof(GetById), new { id = createdConvocation.ConvocationMatchID }, createdConvocation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConvocationMatch>> Update(int id, ConvocationMatch convocation)
        {
            if (id != convocation.ConvocationMatchID)
                return BadRequest("ID mismatch");

            await _convocations.UpdateConvocationMatchAsync(convocation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var convocation = await _convocations.GetConvocationMatchByIdAsync(id);
            if (convocation == null)
                return NotFound();

            await _convocations.DeleteConvocationMatchAsync(id);
            return NoContent();
        }
    }
}