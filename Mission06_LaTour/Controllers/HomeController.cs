using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public IActionResult DataView()
    {
        var movies = _context.Collections
            .Include(c => c.Category)
            .OrderBy(c => c.Title)
            .ToList();

        return View(movies);
    }
    
    [HttpGet]
    public IActionResult MovieCollection()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View("MovieCollection", new Collection());
    }

    [HttpPost]
    public IActionResult MovieCollection(Collection response)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("MovieCollection", response);
        }

        _context.Collections.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {

        var recordToEdit = _context.Collections
            .Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        return View("MovieCollection", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Collection updatedInfo)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("MovieCollection", updatedInfo);
        }

        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("DataView");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Collections
            .SingleOrDefault(x => x.MovieId == id);

        if (recordToDelete == null)
        {
            return NotFound();
        }
        
        return View("Delete", recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Collection collection)
    {
        var recordToDelete = _context.Collections
            .SingleOrDefault(x => x.MovieId == collection.MovieId);

        if (recordToDelete == null)
        {
            return NotFound();
        }
        
        _context.Collections.Remove(recordToDelete);
        _context.SaveChanges();
        return RedirectToAction("DataView");
    }
        
}
