using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Account
{
    [Key]
    public int AccId { get; set; }
    public string AccPhoto { get; set; }
    public string FullName { get; set; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}