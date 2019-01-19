using System.Net;
using System.Threading.Tasks;
using Medicoweb.Account.Contracts;
using Medicoweb.Account.Models;
using Medicoweb.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medicoweb.Web.Controllers
{
    public class AuthController : MedicowebBaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                var token = await _authService.Register(model);
                return Json(token);
            }
            catch (RegistrationFailedException ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] SignInViewModel model)
        {
            try
            {
                var token = await _authService.Signin(model);
                return Json(token);
            }
            catch (SignInFailedException ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
        }
    }
}