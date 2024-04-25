using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAppplication3.DbContexts;
using WebAppplication3.Models; 

public class ProductsController : Controller
{
    private readonly ProductsContext _context;

    public ProductsController(ProductsContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var productCategories = await _context.ProductCategories.ToListAsync();
        ViewBag.ProductCategories = productCategories;
        return View();
    }

    public IActionResult GetProductsByCategory(int categoryId)
    {
        var products = _context.Products.Where(p => p.ProductCategoryId == categoryId).ToList();

        return Json(products);
    }
}
