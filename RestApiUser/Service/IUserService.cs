using RestApiUser.Model;

namespace RestApiUser.Service
{
    public interface IUserService
    {
        User User(int id);
    }
}
