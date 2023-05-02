using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPOS.Data.Entities;
using RestaurantPOS.DTOs.Token;
using RestaurantPOS.Models;
using RestaurantPOS.Service.Interface;

namespace RestaurantPOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly IAuthorizeService _authorizeService;
        public const string SessionKeyName = "_Name";  
        public const string SessionKeyAge = "_Age";   
        public AuthorizeController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }
        [HttpGet]
        [Route("AdminAuth")]
        public IActionResult Index(){
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AdminAuthenticate")]
        // public IActionResult Authenticate(string userName, string pwd)
        public IActionResult AdminAuthenticate([FromForm] Authen input)
        {
            var token = _authorizeService.Authorize(input.userName,input.pwd);

            if (token.Check == false)
            {
                return Unauthorized();
            }
            else{
                HttpContext.Session.SetString("_Name",input.userName);
                HttpContext.Session.SetString("_Age", input.pwd);
                return RedirectToAction("Index","Food");
            }
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Authorize");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        // public IActionResult Authenticate(string userName, string pwd)
        public IActionResult Authenticate(Authen input)
        {
            var token = _authorizeService.Authorize(input.userName,input.pwd);

            if (token.Check == false)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
