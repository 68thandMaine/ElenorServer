using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ProfileContentRepository : RepositoryBase<ProfileContent>, IProfileContentRepository
    {
        public ProfileContentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public virtual List<ProfileContent> GetProfileContent()
        {
            return FindAll().ToList();
        }

        public virtual void CreateProfile(ProfileContent profileContent)
        {
            profileContent.Id = Guid.NewGuid();
            Create(profileContent);
        }

        public virtual void DeleteProfile(ProfileContent profileContent)
        {
            Delete(profileContent);
        }
    }
}
