using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IMessageRepository Message { get; }
        IProfileContentRepository Profile { get; }
        void Save();
    }
}
