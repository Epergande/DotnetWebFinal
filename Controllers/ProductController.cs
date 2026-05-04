using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore.Query.Internal;


public class ProductController : Controller
{
  Random rand = new Random();
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
        model.Code = rand.Next(1000000);
        _dataContext.AddDiscount(model);
        return RedirectToAction("Discount");
      }
    }
    return View();
  }
  
[Authorize(Roles = "employee")]
  public IActionResult EditDiscount() => View();

[Authorize(Roles = "employee")]
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult EditDiscount(Discount model, int id)
  {
    model.DiscountId = id;
    _dataContext.EditDiscount(model);
    return RedirectToAction("Discount");
  }
  

  // [Authorize(Roles = "employee")]
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
