using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanaProject.Models;

namespace NanaProject.Controllers;

[Authorize(Roles = "Admin")][Area("Admin")]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _adminLogger;

    public AdminController(ILogger<AdminController> adminLogger)
    {
        _adminLogger = adminLogger;
    }

    [Route("/Admin/Index")]
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
