

using System.ComponentModel.DataAnnotations;

namespace ShopCartService.Domain.Entities;

public class CartItem
{
    [Key]
    public int Id { get; set; }
    public long ProductId { get; set; }
    public string Name { get; set; } = "";
    public int Price { get; set; }
    public int Quantity { get; set; }

   
}
