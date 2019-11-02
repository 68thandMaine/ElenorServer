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
        public virtual List<Message> GetAllMessages()
        {
            return FindAll().OrderByDescending(x => x.CreatedAt).ToList();
        }

        public virtual void CreateMessage(Message message)
        {
            message.Id = Guid.NewGuid();
            Create(message);
        }

        public virtual Message GetMessageById(Guid Id)
        {
            return FindByCondition(message => message.Id.Equals(Id))
                .DefaultIfEmpty(new Message())
                .FirstOrDefault();
        }

        public virtual void DeleteMessage(Message message)
        {
            Console.WriteLine($"DELETE {message}");
            Delete(message);
        }

    }
}
