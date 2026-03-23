using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options) { }

  public DbSet<Product> Products { get; set; }

  public DbSet<Category> Categories { get; set; }

  public DbSet<Discount> Discounts { get; set; }

  public DbSet<Customer> Customers { get; set;  } 

public void AddCustomer(
  string companyName ,
 string address,
 string city,
 string region,
 string postalCode,
 string country,
 string phone,
 string fax

 )
    {
        var newCustomer = new Customer { 
          CompanyName = companyName ,
          Address = address ,
          City = city,
          Region = region,
          PostalCode = postalCode,
          Country = country,
          Phone = phone,
          Fax = fax
        };
        this.Customers.Add(newCustomer);
        this.SaveChanges();
    }
}
