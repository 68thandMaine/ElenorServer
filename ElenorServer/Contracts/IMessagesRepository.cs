using System;
using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMessagesRepository : IRepositoryBase<Messages>
    {
        List<Messages> GetAllMessages();
        Messages GetMessageById(Guid messageId);
        void CreateMessage(Messages message);
        //void UpdateMessage(Messages dbMessage, Messages message);
        //void DeleteMessage(Messages message);
    }
}
