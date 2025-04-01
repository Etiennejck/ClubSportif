using ClubSportif.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubSportif.BLL.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessagesAsync();
        Task<Message> GetMessageByIdAsync(int id);
        Task<Message> CreateMessageAsync(Message message);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(int id);
    }
}
