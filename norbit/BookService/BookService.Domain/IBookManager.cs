namespace BookService.Domain;

public interface IBookManager
{
    List<Book> GetAll();
    Book? GetById(long id);
    Book Create(Book book);
    Book? Update(Book book);
    Book? Delete(long id);
    Book? GetByTitle(string title);
}
