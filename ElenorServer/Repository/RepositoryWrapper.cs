using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IMessageRepository _Message;

        public IMessageRepository Message
        {
            get
            {
                if (_Message == null)
                {
                    _Message = new MessageRepository(_repoContext);
                }
                return _Message;
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
