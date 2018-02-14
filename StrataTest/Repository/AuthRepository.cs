using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Commands;
using StrataTest.DbContext;
using StrataTest.Domain;
using StrataTest.Models;

namespace StrataTest.Repository
{

    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;
        private UserManager<UserModel> _userManager;

        public AuthRepository()
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

        public async Task<UserModel> Authenticate(string name, string password)
        {
            UserModel user = await _userManager.FindAsync(name, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}