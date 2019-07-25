using System;
using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        List<Message> GetAllMessages();
        Message GetMessageById(Guid messageId);
        void CreateMessage(Message message);
        //void UpdateMessage(Message dbMessage, Message message);
        //void DeleteMessage(Message MessageArray)
        void DeleteMessage(Message message);
    }
}
