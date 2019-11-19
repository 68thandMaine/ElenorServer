using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Message
{
    public class MessageForCreationDto
    {
        [RequiredAttribute(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [RequiredAttribute(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [RequiredAttribute(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Subject { get; set; }
        [RequiredAttribute(ErrorMessage = "A message is required")]
        public string Note { get; set; }
        public string CreatedAt { get; set; }

    }
}
