using System;
using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        IEnumerable<Message> GetAllMessages();
        Message GetMessageById(Guid messageId);
        void CreateMessage(Message message);
        void UpdateMessage(Message message);
        void DeleteMessage(Message message);
    }
}
