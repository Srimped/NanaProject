using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NanaProject.Models;
public class Account : IdentityUser
{
    [Required]
    public string AccPhoto { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string FullName { get; set; }
    [Required]
    public DateTime DOB { get; set; }
    [Required]
    public string Address { get; set; }
}