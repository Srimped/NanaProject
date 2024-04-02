using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NanaProject.ViewModels;

public class FoodCreateEditViewModel
{
    [Key]
    public int FoodId { get; set; }
    public string FoodPhoto { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string FoodName { get; set; }
    public int CateId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Status { get; set; }
    public string FoodDescription { get; set; }
    public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
}