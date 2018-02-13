using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Interfaces;
using StrataTest.Models;
using StrataTest.Repository;
using StrataTest.Requests;

namespace StrataTest.Controllers
{
    [RoutePrefix("api/User")]

    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        private AuthRepository _authRepository = null;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _authRepository = new AuthRepository();

        }

        [AllowAnonymous]
        [Route("Authenticate")]
        public async Task<IHttpActionResult> Authenticate(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser result = await _authRepository.Authenticate(userModel.Name, userModel.Password);

            if (result.Claims.Count  < 1)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }


        [HttpGet]
        [Route("userByName/{userName}")]
        public IHttpActionResult GetUserByName(string userName)
        {
            try
            {
                return Ok(_userRepository.GetUserByName(userName));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("userByEmail/{emailAddress}")]
        public IHttpActionResult GetUserByEmail(string emailAddress)
        {
            try
            {
                return Ok(_userRepository.GetUserByName(emailAddress));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
