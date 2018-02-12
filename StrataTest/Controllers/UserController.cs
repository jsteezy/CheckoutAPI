using System;
using System.Web;
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
        [Route("api/authenticate/{emailAddress}/{")]
        public IHttpActionResult Authenticate([FromBody]AuthenticateUserRequest request)
        {
            try
            {
                return Ok(_user.Authenticate(request.EmailAddress, request.Password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/userByName/{userName}")]
        public IHttpActionResult GetUserByName(string userName)
        {
            try
            {
                return Ok(_user.GetUserByName(userName));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/userByEmail/{emailAddress}")]
        public IHttpActionResult GetUserByEmail(string emailAddress)
        {
            try
            {
                return Ok(_user.GetUserByName(emailAddress));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
