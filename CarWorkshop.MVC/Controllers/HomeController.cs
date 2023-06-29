using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                Name = "Filip",
                LastName = "Szerszen"
            },
            new Person()
            {
                Name = "Anna",
                LastName = "Konopka"
            },
            new Person()
            {
                Name = "Łukasz",
                LastName = "Michalak"
            }
        };
        return View(model);
    }

    public IActionResult About()
    {
        var model = new About() { 
            Title = "Przykładowy nagłówek",
            Description = "Przykładowy opis",
            Tags = new List<string>
            {
                "muzyka",
                "książki",
                "podróże"
            }
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
