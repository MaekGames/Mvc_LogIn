using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppTask.Models;
using WebAppTask.Services;


namespace WebAppTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public AccountController(IUserAuthenticationService authService)
        {
            this._authService = authService;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 2)
            {
                HttpContext.Session.SetString("username", model.Username);
                return RedirectToAction("Index", "Products");
            }
            if (result.StatusCode == 1)
            {
                HttpContext.Session.SetString("username", model.Username);
                return RedirectToAction("UserView", "Products");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            HttpContext.Session.Remove("username");

            return RedirectToAction(nameof(Login));
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin(RegistrationModel model)
        {
            model = new RegistrationModel
            {
                Username="ad",
                Email="admin@gmail.com",
                FirstName="John",
                LastName="Doe",
                Password="Unitytest1!"
            };
            model.Role = "admin";
            var result = await this._authService.RegisterAsync(model);
            return Ok(result);
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        //[Authorize]
        //[HttpPost]
        /*public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(ChangePassword));
        }*/
    }
}
