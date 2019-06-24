using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MessagesRepository : RepositoryBase<Messages>, IMessagesRepository
    {
        public MessagesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Messages> GetAllMessages()
        {
            return FindAll().ToList();
        }

        public void CreateMessage(Messages message)
        {
            message.Id = Guid.NewGuid();
            Create(message);
        }

        public Messages GetMessageById(Guid Id)
        {
            return FindByCondition(message => message.Id.Equals(Id))
                .DefaultIfEmpty(new Messages())
                .FirstOrDefault();
        }
    }
}
