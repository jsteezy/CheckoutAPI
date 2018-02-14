using StrataTest.Domain;

namespace StrataTest.Interfaces
{
    public interface IUserRepository
    {
        UserModel GetUserByName(string userName);

        UserModel GetUserByEmail(string emailAddress);

    }
}