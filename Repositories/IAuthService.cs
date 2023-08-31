using backend_api.Models;

namespace backend_api.Repositories;

public interface IAuthService 
{
    User CreateUser(User user);
    string SignIn(string UserName, string password);
}