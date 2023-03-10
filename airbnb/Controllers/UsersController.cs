using airbnb.DTO;
using airbnb.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace airbnb.Controllers
{
    public class UsersController : Controller
    {
        private readonly AirbnbDbContext _context;

        public UsersController(AirbnbDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO model, string? returnurl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Customer user = _context.Customers.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();

            if (user != null)
            {
                ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);

                await HttpContext.SignInAsync(cp);

                if (returnurl != null)
                {
                    return LocalRedirect(returnurl);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password, Check your informtion again!");
                return View(model);
            }
           
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = new Customer()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DOB = model.DOB,
                    Email = model.Email,
                    Password = model.Password
                };
                _context.Customers.Add(user);
                _context.SaveChanges();

                ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);

                await HttpContext.SignInAsync(cp);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}
