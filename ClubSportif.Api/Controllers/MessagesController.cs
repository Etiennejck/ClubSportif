using ClubSportif.BLL.Interfaces;
using ClubSportif.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessageById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> CreateMessage([FromBody] Message message)
        {
           try
            {
                var createdMessage = await _messageService.CreateMessageAsync(message);
                return CreatedAtAction(nameof(GetMessageById), new { id = createdMessage.MessageID }, createdMessage);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(int id, [FromBody] Message message)
        {
            if (id != message.MessageID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _messageService.UpdateMessageAsync(message);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return NoContent();
        }
    }
}