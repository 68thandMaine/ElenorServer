using System;
namespace Entities.DataTransferObjects
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Note { get; set; }
        public string CreatedAt { get; set; }
        public bool Opened { get; set; }
        public bool Replied { get; set; }
        public string RepliedMessage { get; set; }
    }
}
