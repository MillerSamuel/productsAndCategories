using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using productsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

namespace productsAndCategories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _context=context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.allProducts=_context.Products.ToList();
        return View();
    }

    [HttpGet("categories")]
    public IActionResult categories()
    {
        ViewBag.allCategories=_context.Categories.ToList();
        return View("Categories");
    }


    [HttpPost("addProduct")]
    public IActionResult addProduct(Product newProd)
    {
        ViewBag.allProducts=_context.Products.ToList();
        if (ModelState.IsValid){
            _context.Add(newProd);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else{
            return View("Index");
        }
    }

    [HttpPost("addCategory")]
    public IActionResult addCategory(Category newCat)
    {
        ViewBag.allCategories=_context.Categories.ToList();
        if (ModelState.IsValid){
            _context.Add(newCat);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        else{
            return View("Categories");
        }
    }

    [HttpGet("products/{id}")]
    public IActionResult OneProduct(int id)
    {
        ViewBag.allCategories=_context.Categories.Include(a=>a.allProducts).ThenInclude(b=>b.Product).ToList();
        ViewBag.OneProduct=_context.Products.FirstOrDefault(a=>a.ProductId==id);
        return View("OneProduct");
    }

    [HttpGet("Categories/{id}")]
    public IActionResult OneCategory(int id)
    {
        ViewBag.allProducts=_context.Products.Include(a=>a.allCategories).ThenInclude(b=>b.Category).ToList();
        ViewBag.OneCategory=_context.Categories.FirstOrDefault(a=>a.CategoryId==id);
        return View("OneCategory");
    }

    [HttpPost("relationship/add")]
    public IActionResult addRelationship(Relationship newRelationship)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newRelationship);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        else{
            return View("OneProduct");
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
