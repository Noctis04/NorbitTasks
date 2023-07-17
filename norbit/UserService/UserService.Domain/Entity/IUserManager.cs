
namespace UserService.Domain.Entity;

public interface IUserManager
{
    List<User> GetAll();
    User? GetById(long id);
    User Create(User user);
    User? Update(User user);
    User? Delete(long id);
}
