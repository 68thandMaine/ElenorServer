using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public List<Message> GetAllMessages()
        {
            return FindAll().ToList();
        }

        public void CreateMessage(Message message)
        {
            message.Id = Guid.NewGuid();
            Create(message);
        }

        public Message GetMessageById(Guid Id)
        {
            return FindByCondition(message => message.Id.Equals(Id))
                .DefaultIfEmpty(new Message())
                .FirstOrDefault();
        }

        public void DeleteMessage(Message message)
        {
            Delete(message);
        }

    }
}
