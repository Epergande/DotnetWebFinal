using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
      // DateTime thisDay = DateTime.Today;

  // this controller depends on the NorthwindRepository
  private DataContext _dataContext;
  public ProductController(DataContext db) => _dataContext = db;
  public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  public IActionResult Index(int id) => View(_dataContext.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));
public IActionResult Discount(int id) => View(_dataContext.Discounts);
}
// .Where(p => p.EndTime !< thisDay)