using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Pet
{
    public int Id { get; set; }
    public string Photo { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public Decimal Old { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Description { get; set; }
}