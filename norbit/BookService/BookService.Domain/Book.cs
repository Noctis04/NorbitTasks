using System;
using System.ComponentModel.DataAnnotations;


namespace BookService.Domain;

public class Book
{
    [Key]
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public decimal Price { get; set; }
    public string Genre { get; set; } = "";
    public DateTime? PublicationDate { get; set; }
    public string Description { get; set; } = "";
    public string? CoverImageURL { get; set; } = "";
    public int Amount { get; set; }

}
