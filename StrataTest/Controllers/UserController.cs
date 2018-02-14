using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StrataTest.Commands;
using StrataTest.Interfaces;
using StrataTest.Models;
using StrataTest.Repository;

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
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserCommand userCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _authRepository.AddUser(userCommand);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
            return Ok();
        }

        [AllowAnonymous]
        [Route("Authenticate")]
        public async Task<IHttpActionResult> Authenticate(UserCommand userCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser result = await _authRepository.Authenticate(userCommand.UserName, userCommand.Password);

            if (result == null)
            {
                return BadRequest("Could not find user");
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

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
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
