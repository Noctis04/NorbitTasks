using UserService.Domain.Entity;
using UserService.Infrastructure.Contexts;

namespace UserService.Infrastructure.Managers;

public class UserManager : IUserManager
{
    public static long UserId;
    private readonly UserContext _context;
    public UserManager(UserContext context)
    {
        _context = context;
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User? GetById(long id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }
    public long GetUserId(long userId)
    {
        userId = UserId;
        var existingUser = _context.Users.FirstOrDefault(x => (x.Id == userId));

        if (existingUser is null)
            return 0;
        else
           return existingUser.Id;
    }
    public User Create(User user)
    {
        var entry = _context.Add(user);
        _context.SaveChanges();
        UserId = user.Id;
        return entry.Entity;
        

    }
    public User? Update(User user)
    {
        var existingUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (existingUser is null)
        {
            return null;
        }

        existingUser.Login = user.Login;
        existingUser.Password = user.Password;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.EmailAddress = user.EmailAddress;

        var entry = _context.Update(user);
        _context.SaveChanges();
        return entry.Entity;
    }
    public User? Delete(long id)
    {
        var existingUser = _context.Users.FirstOrDefault(x => x.Id == id);
        if (existingUser is null)
        {
            return null;
        }

        var entry = _context.Remove(existingUser);
        _context.SaveChanges();
        return entry.Entity;
    }
}
