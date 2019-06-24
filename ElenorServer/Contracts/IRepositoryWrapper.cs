using System;
namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IMessagesRepository Messages { get; }

        void Save();
    }
}
