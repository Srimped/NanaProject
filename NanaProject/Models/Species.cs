using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Species
{
    [Key]
    public int SpecId { get; set; }
    public string SpecName { get; set; }
    public string SpecDescription { get; set; }
    public virtual ICollection<Pet> Pets { get; set; }
}