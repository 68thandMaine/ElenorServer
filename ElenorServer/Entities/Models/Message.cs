using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("messages")]
    public class Messages
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The first name field is required.")]
        [StringLength(20, ErrorMessage = "There can only be 20 characters in the first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The last name field is required.")]
        [StringLength(40, ErrorMessage = "There can only be 40 characters in the last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The subject field is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The message field is required.")]
        [StringLength(1500, ErrorMessage = "There can only be 1500 characters in a message.")]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool Opened { get; set; }

        public bool Replied { get; set; }
    }
}
