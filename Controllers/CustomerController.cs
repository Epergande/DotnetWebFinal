using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Controllers
{
  public class CustomerController(DataContext db) : Controller
    {
     // this controller depends on the DataContext
        private readonly DataContext _dataContext = db;

        // public IActionResult Regester() => View(_dataContext.Customers);
    }
}
