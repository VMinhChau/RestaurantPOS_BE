using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.DTOs.Token;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizeService _authorizeService;
        public AuthorizeController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string userName, string pwd)
        {
            var token = _authorizeService.Authorize(userName,pwd);

            if (token.Check == false)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
