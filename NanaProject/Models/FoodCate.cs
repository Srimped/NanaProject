using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class FoodCate
{
    public int CateId { get; set; }
    public string CateName { get; set; }
    public string CateDescription { get; set; }
    public virtual ICollection<Food> Foods { get; set; }
}