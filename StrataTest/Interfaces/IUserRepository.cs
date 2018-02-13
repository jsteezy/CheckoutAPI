using StrataTest.Models;

namespace StrataTest.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUserByName(string userName);

        UserModel GetUserByEmail(string emailAddress);

        void AddUser(UserModel userModel);
    }
}