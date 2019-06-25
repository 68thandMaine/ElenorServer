using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IMessagesRepository _messages;

        public IMessagesRepository Messages
        {
            get
            {
                if (_messages == null)
                {
                    _messages = new MessagesRepository(_repoContext);
                }
                return _messages;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public RepositoryWrapper()
        {
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
