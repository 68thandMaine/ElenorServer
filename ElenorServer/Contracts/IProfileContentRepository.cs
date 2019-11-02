using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IProfileContentRepository : IRepositoryBase<ProfileContent>
    {
        List<ProfileContent> GetProfileContent();
        void CreateProfile(ProfileContent profileContent);
        void DeleteProfile(ProfileContent profileContent);
    }
}
