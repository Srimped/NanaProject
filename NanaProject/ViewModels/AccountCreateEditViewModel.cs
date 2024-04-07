using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NanaProject.ViewModels;

public class AccountCreateEditViewModel : IdentityUser
{
    public string AccPhoto { get; set; }
    public string FullName { get; set; }
    public DateTime DOB { get; set; }
    public string Address { get; set; }
    public IList<string> RoleNames { get; set; }
}