using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace Northwind.Controllers
{
  public class CustomerController(DataContext db) : Controller
    {
     // this controller depends on the DataContext
        private readonly DataContext _dataContext = db;


[HttpGet]

        public IActionResult Regester() { 
            return View("Regester");
        }
  [HttpGet]
public IActionResult Customers()
{
    // Fetch the list of customers from the database
    var model = _dataContext.Customers.ToList();
    
    // This will look for the "Customers.cshtml" view
    return View(model);
}
        

    [HttpPost]
    public IActionResult Regester(string companyName , string address , string city,
 string region,
 string postalCode,
 string country,
 string phone,
 string fax)
    {
         if (db.Customers.Any(c => c.CompanyName == companyName))
      {
        Console.WriteLine("error");
        return View("Regester");
      }
      else
      {
        db.AddCustomer(companyName,address,city,
          region,
          postalCode,
          country,
          phone,
          fax
  );
   return RedirectToAction("Customers"); // Redirect after success
      }
     

       
    }
    }

}
