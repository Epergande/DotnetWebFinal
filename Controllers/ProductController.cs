using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class ProductController : Controller
{
  // this controller depends on the NorthwindRepository
  private DataContext _dataContext;
  public ProductController(DataContext db) => _dataContext = db;
  public IActionResult Category() => View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  public IActionResult Index(int id)
  {
    ViewBag.id = id;
    return View(_dataContext.Categories.OrderBy(c => c.CategoryName));
  }
  public IActionResult Discount(int id) => View(_dataContext.Discounts);


  [Authorize(Roles = "employee")]
  public IActionResult AddDiscount() => View();
  [Authorize(Roles = "employee")]
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult AddDiscount(Discount model)
  {
    if (ModelState.IsValid)
    {
      if (_dataContext.Discounts.Any(b => b.DiscountId == model.DiscountId))
      {
        ModelState.AddModelError("", "Name must be unique");
      }
      else
      {
        _dataContext.AddDiscount(model);
        return RedirectToAction("Index");
      }
    }
    return View();
  }
}
