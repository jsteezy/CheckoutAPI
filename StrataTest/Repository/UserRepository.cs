using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Commands;
using StrataTest.DbContext;
using StrataTest.Domain;
using StrataTest.Interfaces;
using StrataTest.Models;

namespace StrataTest.Repository
{

    public class UserRepository : IDisposable, IUserRepository
    {
        private AuthContext _ctx;
        private UserManager<UserModel> _userManager;

        public UserRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<UserModel>(new UserStore<UserModel>(_ctx));
        }

        public async Task<IdentityResult> AddUser(UserCommand userCommand)
        {
            UserModel user = new UserModel
            {
                UserName = userCommand.UserName
            };

            var result = await _userManager.CreateAsync(user, userCommand.Password);

            return result;
        }

        public async Task<UserModel> Authenticate(string userName, string password)
        {
            UserModel user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<UserModel> GetUserByName(string userName)
        {
            UserModel user = await _userManager.FindByNameAsync(userName);

            return user;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            UserModel user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<UserModel> GetUserById(string userId)
        {
            UserModel user = await _userManager.FindByIdAsync(userId);

            return user;
        }

        public void Dispose(bool disposing)
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

        public void Dispose()
        {
            _ctx?.Dispose();
            _userManager?.Dispose();
        }
    }
}