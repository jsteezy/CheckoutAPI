using StrataTest.Models;

namespace StrataTest.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByName(string userName);

        User GetUserByEmail(string emailAddress);
    }
}