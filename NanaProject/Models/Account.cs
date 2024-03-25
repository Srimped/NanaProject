using System.ComponentModel.DataAnnotations;

namespace NanaProject.Models;
public class Account
{
    public int AccId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}