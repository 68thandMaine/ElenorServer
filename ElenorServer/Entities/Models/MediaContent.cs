using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entites.models 
{
  [Table("ArtWork")]
  public class ArtWork
  {
    [Key]
    [Column("Id")]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Media { get; set; }
    public string Dimensions { get; set; }
    public string Created { get; set; }
    public string Category { get; set; }
    public string ImageFile { get; set; }
    public bool ForSale { get; set; }
    public int Prince { get; set; }
  }
}