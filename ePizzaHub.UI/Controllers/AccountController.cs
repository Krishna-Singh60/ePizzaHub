using ePizzaHub.Model;
using ePizzaHub.Services.Implemention;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace ePizzaHub.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        private void GenerateTicket(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, string.Join(",", user.Roles)),
                new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(user))

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var pricipal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
            };
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal, properties);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {

                var user = _userService.ValidateUser(model.Email,model.Password);
              
                if (user != null)
                {
                    GenerateTicket(user);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }

                }
                else
                {
                    ModelState.AddModelError("Invalid", "Invalid Email or Password");
                }
             }
            return View();
        }

        public IActionResult Logout()
        {
           HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("Login");
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}
