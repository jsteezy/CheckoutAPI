using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using StrataTest.Commands;
using StrataTest.Domain;

namespace StrataTest.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUser(UserCommand userCommand);
        Task<UserModel> Authenticate(string userName, string password);
        Task<UserModel> GetUserByName(string userName);
        Task<UserModel> GetUserByEmail(string email);
        Task<UserModel> GetUserById(string userId);
        void Dispose(bool disposing);
        void Dispose();
    }
}