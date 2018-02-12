using StrataTest.Models;

namespace StrataTest.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);

        User GetUserByEmail(string emailAddress);

        void AddUser(User user);

        bool Authenticate(string emailAddress, string password);
    }
}