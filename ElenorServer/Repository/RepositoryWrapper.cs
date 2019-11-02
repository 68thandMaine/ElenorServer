using System;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IMessageRepository _Message;
        private IProfileContentRepository _Profile;

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

        public IProfileContentRepository Profile
        {
            get
            {
                if (_Profile == null)
                {
                    _Profile = new ProfileContentRepository(_repoContext);
                }
                return _Profile;
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
