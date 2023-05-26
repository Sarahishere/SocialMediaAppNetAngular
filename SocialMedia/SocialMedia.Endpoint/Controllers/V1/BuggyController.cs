
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Persistence;
using SocialMedia.Persistence.Interfaces;

namespace SocialMedia.Endpoint.Controllers.V1
{
    //this controller is for testing error handling middleware
    public class BuggyController : BaseController
    {
        public BuggyController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecrete()
        {
            return "Secrete text";
        }

        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var id = Guid.NewGuid();
            var nullUser = _unitOfWork.Users.GetByIdAsync(id);
            return nullUser.ToString();
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was a bad request");
        }
    }
}