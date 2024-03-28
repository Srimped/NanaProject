using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Pet
{
    [Key]
    public int Id { get; set; }
    public string Photo { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }
    public int TypeId { get; set; }
    [Required]
    public float Old { get; set; }
    [Required]
    public DateTime CheckIn { get; set; }
    [Required]
    public DateTime CheckOut { get; set; }
    public string Description { get; set; }
}