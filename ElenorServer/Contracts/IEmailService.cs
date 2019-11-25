using System;
using System.Net.Http;
using Entities.Models;

namespace Contracts
{
    public interface IEmailService
    {
        void SendMessage(Message message);
    }
}
