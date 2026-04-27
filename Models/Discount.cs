using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Discount
{
  public int DiscountId { get; set; }
  public int Code { get; set; }
  [Required]
  public DateTime StartTime { get; set; }
  [Required]
  public DateTime EndTime { get; set; }
  public int ProductId { get; set; }
  [Column(TypeName = "decimal(5,2)")]
  public decimal DiscountPercent { get; set; }
  [Required]
  public string Title { get; set; }
  public string Description { get; set; }


  public Product Product { get; set; }
}
