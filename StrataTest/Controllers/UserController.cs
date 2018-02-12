using System;
using System.Web.Http;
using StrataTest.Interfaces;
using StrataTest.Requests;

namespace StrataTest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("api/{user}/authenticate")]
        public IHttpActionResult Authenticate([FromBody]AuthenticateUserRequest request)
        {
            try
            {
                return Ok(_user.Authenticate(request.EmailAddress, request.Password));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/{user}/userByName/{userName}")]
        public IHttpActionResult GetUserByName(string userName)
        {
            try
            {
                return Ok(_user.GetUserByName(userName));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("api/{user}/userByEmail/{userName}")]
        public IHttpActionResult GetUserByEmail(string emailAddress)
        {
            try
            {
                return Ok(_user.GetUserByName(emailAddress));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
