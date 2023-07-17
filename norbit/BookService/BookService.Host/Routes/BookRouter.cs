using BookService.Domain;

namespace BookService.Host.Routes;

public static class BookRouter
{
    public static WebApplication AddBookRouter(this WebApplication application)
    {
        // Производим группировку логики.
        var bookGroup = application.MapGroup("/api/books");

        bookGroup.MapGet(pattern: "/", handler: GetAllBooks);
        bookGroup.MapGet(pattern: "/{id:long}", handler: GetBookById);
        bookGroup.MapGet(pattern: "/{title}", handler: GetBookByTitle);
        bookGroup.MapPost(pattern: "/", handler: CreateBook);
        bookGroup.MapPut(pattern: "/", handler: UpdateBook);
        bookGroup.MapDelete(pattern: "/{id:long}", handler: DeleteBook);

        return application;
    }
    private static IResult GetAllBooks(IBookManager bookManager)
    {
        var books = bookManager.GetAll();
        return Results.Ok(books);
    }
    private static IResult GetBookById(IBookManager bookManager, long id)
    {
        var book = bookManager.GetById(id);

        if (book != null)
            return Results.Ok(book); 
        else
            return Results.NotFound();
    }
    private static IResult GetBookByTitle(IBookManager bookManager, string title)
    {
        var book = bookManager.GetByTitle(title);

        if (book != null)
            return Results.Ok(book);
        else
            return Results.NotFound();
    }

    private static IResult CreateBook(IBookManager bookManager, Book newBook)
    {
        var createdBook = bookManager.Create(newBook);
        return Results.Ok(createdBook);
    }

    private static IResult UpdateBook(IBookManager bookManager, Book updatedBook)
    {
        var success = bookManager.Update(updatedBook);

        if (success is null)
            return Results.NotFound();
        else
            return Results.Ok(success);
    }

    private static IResult DeleteBook(IBookManager bookManager, long id)
    {
        var success = bookManager.Delete(id);

        if (success is null)
            return Results.NoContent();
        else
            return Results.Ok(success);
    }
   
}
