using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Food
{
    [Key]
    public int FoodId { get; set; }
    public string FoodPhoto { get; set; }
    public string FoodName { get; set; }
    public int CateId { get; set; }
    public int Quantity { get; set;}
    public int Status { get; set; }
    public string FoodDescription { get; set; }
}