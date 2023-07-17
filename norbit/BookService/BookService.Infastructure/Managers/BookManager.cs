using BookService.Domain;
using BookService.Infastructure.Contexts;

namespace BookService.Infastructure.Managers;

public class BookManager : IBookManager
{
    private readonly BookContext _context;

    public BookManager(BookContext context)
    {
        _context = context;
    }

    public List<Book> GetAll()
    {
        return _context.Books.ToList();
    }

    public Book? GetById(long id)
    {
        return _context.Books.FirstOrDefault(x => x.Id == id);
    }
    public Book? GetByTitle(string title)
    {
        return _context.Books.FirstOrDefault(x => x.Title == title);
    }

    public Book Create(Book book)
    {
        var entry = _context.Add(book);
        _context.SaveChanges();
        return entry.Entity;
    }

    public Book? Update(Book book)
    {
        var existingBook = _context.Books.FirstOrDefault(x => x.Id == book.Id);
        if (existingBook == null)
        {
            return null;
        }

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Description = book.Description;
        existingBook.Price = book.Price;
        existingBook.PublicationDate = book.PublicationDate;
        existingBook.CoverImageURL = book.CoverImageURL;
        existingBook.Genre = book.Genre;
        existingBook.Amount = book.Amount;

        var entry = _context.Update(existingBook);
        _context.SaveChanges();
        return entry.Entity;
    }

    public Book? Delete(long id)
    {
        var existingBook = _context.Books.FirstOrDefault(x => x.Id == id);
        if (existingBook == null)
        {
            return null;
        }

        var entry = _context.Remove(existingBook);
        _context.SaveChanges();
        return entry.Entity;
    }

   

}
