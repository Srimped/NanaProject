using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Type
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }
    public string TypeDescription { get; set; }
    public virtual ICollection<Pet> Pets { get; set; }
}