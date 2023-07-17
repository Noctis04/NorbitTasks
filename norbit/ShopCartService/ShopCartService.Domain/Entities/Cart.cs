

using System.ComponentModel.DataAnnotations;

namespace ShopCartService.Domain.Entities;

public class Cart
{
    [Key]
    public long Id { get; set; }
    public long UserId { get; set; }
    public List<CartItem> Items { get; set; }
    public decimal TotalPrice
    {
        get { return Items.Sum(item => item.Price * item.Quantity); }
    }
}
