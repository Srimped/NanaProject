using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Species
{
    [Key]
    public int SpecId { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string SpecName { get; set; }
    public string SpecDescription { get; set; }
    public virtual ICollection<Pet> Pets { get; set; }
}