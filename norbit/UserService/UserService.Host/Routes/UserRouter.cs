using UserService.Domain.Entity;

namespace UserService.Host.Routes;

public static class UserRouter
{
    public static WebApplication AddUserRouter(this WebApplication application)
    {
        var userGroup = application.MapGroup("/api/users");

        userGroup.MapGet(pattern: "/", handler: GetAllUsers);
        userGroup.MapGet(pattern: "/{id:long}", handler: GetUserById);
        userGroup.MapPost(pattern: "/", handler: CreateUser);
        userGroup.MapPut(pattern: "/", handler: UpdateUser);
        userGroup.MapDelete(pattern: "/{id:long}", handler: DeleteUser);

        return application;
    }
    private static IResult GetAllUsers(IUserManager userManager)
    {
        var users = userManager.GetAll();
        return Results.Ok(users);
    }
    private static IResult GetUserById(long id, IUserManager userManager)
    {
        var user = userManager.GetById(id);
        return user is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
    private static IResult CreateUser(User user, IUserManager userManager)
    {
        var createdUser = userManager.Create(user);
        return Results.Ok(createdUser);
    }
    private static IResult UpdateUser(User user, IUserManager userManager)
    {
        var updatedUser = userManager.Update(user);
        return updatedUser is null
            ? Results.NotFound()
            : Results.Ok(updatedUser);
    }
    private static IResult DeleteUser(long id, IUserManager userManager)
    {
        var deletedUser = userManager.Delete(id);
        return deletedUser is null
            ? Results.NotFound()
            : Results.Ok(deletedUser);
    }

}
