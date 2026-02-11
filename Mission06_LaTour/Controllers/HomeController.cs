using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_LaTour.Models;

namespace Mission06_LaTour.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;
    
    public HomeController(MovieCollectionContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }
    [HttpGet]
    public IActionResult MovieCollection()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieCollection(Collection response)
    {
        _context.Collections.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
        
}