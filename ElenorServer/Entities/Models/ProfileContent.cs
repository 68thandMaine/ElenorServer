using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
  [Table("ProfileContent")]
  public class ProfileContent
  {
    [Key]
    [Column("Id")]
    public Guid Id { get; set; }

    public string DisplayName { get; set; }
    public string ImageFile { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string About { get; set; }
    public string Websites { get; set; }
  }
}