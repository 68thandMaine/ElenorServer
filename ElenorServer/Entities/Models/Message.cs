using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The first name field is required.")]
        [StringLength(20, ErrorMessage = "There can only be 20 characters in the first name.")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "The last name field is required.")]
        [StringLength(40, ErrorMessage = "There can only be 40 characters in the last name.")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "The subject field is required.")]
        public virtual string Subject { get; set; }

        [Required(ErrorMessage = "The message field is required.")]
        [StringLength(1500, ErrorMessage = "There can only be 1500 characters in a message.")]
        public virtual string Note { get; set; }

        public virtual string CreatedAt { get; set; }

        public virtual bool Opened { get; set; }

        public virtual bool Replied { get; set; }

        public virtual string RepliedMessage { get; set; }
    }
}
