using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Discount> Discounts { get; set; }
  public DbSet<Customer> Customers { get; set; }

  public void AddCustomer(Customer customer)
  {
    Customers.Add(customer);
    SaveChanges();
  }
  public void EditCustomer(Customer customer)
  {
    var customerToUpdate = Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
    customerToUpdate.Address = customer.Address;
    customerToUpdate.City = customer.City;
    customerToUpdate.Region = customer.Region;
    customerToUpdate.PostalCode = customer.PostalCode;
    customerToUpdate.Country = customer.Country;
    customerToUpdate.Phone = customer.Phone;
    customerToUpdate.Fax = customer.Fax;
    SaveChanges();
  }
   public void AddDiscount(Discount discount)
  {
    discount.Product = Products.FirstOrDefault(p => p.ProductId == discount.ProductId);
    discount.DiscountPercent = Math.Round(discount.DiscountPercent, 2);
    Console.WriteLine(discount.DiscountPercent);
    this.Add(discount);
    
    this.SaveChanges();
  }
  public void DeleteDiscount(Discount discount)
  {
    this.Remove(discount);
    this.SaveChanges();
  }
  public void EditDiscount(Discount discount)
  {
    var discountToUpdate = Discounts.FirstOrDefault(c => c.DiscountId == discount.DiscountId);
    Console.WriteLine(discount.Title + " " + discountToUpdate.Title);
    Console.WriteLine(discount.DiscountId + " " + discountToUpdate.DiscountId);
    discountToUpdate.Code = discount.Code;
    discountToUpdate.StartTime = discount.StartTime;
    discountToUpdate.EndTime = discount.EndTime;
    discountToUpdate.ProductId = discount.ProductId;
    discountToUpdate.DiscountPercent = discount.DiscountPercent;
    discountToUpdate.Title = discount.Title;
    discountToUpdate.Description = discount.Description;
    discountToUpdate.Product = discount.Product;
    this.SaveChanges();
  }
}
