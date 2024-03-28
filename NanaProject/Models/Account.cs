using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Account
{
    [Key]
    public int AccId { get; set; }
    public string AccPhoto { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string FullName { get; set; }
    [Required]
    public DateTime DOB { get; set; }
    [Display(Name = "Office Email")]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
    ErrorMessage = "Invalid email format")]
    [Required]
    public string Email { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters")]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string Address { get; set; }
}