using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IMessageRepository Message { get; }

        void Save();
    }
}
