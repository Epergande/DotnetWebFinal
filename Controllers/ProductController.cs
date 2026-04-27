using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
  // this controller depends on the NorthwindRepository
  private DataContext _dataContext;
  public ProductController(DataContext db) => _dataContext = db;
  public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  public IActionResult Index(int id){
    ViewBag.id = id;
    return View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  }
public IActionResult Discount(int id) => View(_dataContext.Discounts);

public IActionResult AddDiscount() => View();

[HttpPost]
public IActionResult DeleteDiscount(int id)
{
    var discount = _dataContext.Discounts.Find(id);
    if (discount != null)
    {
        _dataContext.DeleteDiscount(discount);
        _dataContext.SaveChanges();
    }
    return RedirectToAction("Discount");
}
}
