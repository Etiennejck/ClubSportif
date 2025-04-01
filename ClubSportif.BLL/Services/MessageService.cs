using ClubSportif.BLL.Interfaces;
using ClubSportif.DAL;
using ClubSportif.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Services
{
    public class MessageService : IMessageService
    {

        private readonly ClubSportifDbContext _context;

        public MessageService(ClubSportifDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetAllMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<Message> CreateMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task UpdateMessageAsync(Message message)
        {
            _context.Entry(message).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}
