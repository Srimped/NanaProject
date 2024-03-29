using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage;

namespace NanaProject.Models;
public class Category
{
    [Key]
    public int CateId { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string CateName { get; set; }
    public string CateDescription { get; set; }
    public virtual ICollection<Food> Foods { get; set; }
}