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
using Microsoft.EntityFrameworkCore;

namespace airbnb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AirbnbDbContext _context;

        public AccountController(AirbnbDbContext context)
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
                ci.AddClaim(new Claim(ClaimTypes.Name, user.CustomerId.ToString()));
                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);

                await HttpContext.SignInAsync(cp);

                if (returnurl != null)
                {
                    return LocalRedirect(returnurl);
                }

                return RedirectToAction("getAll", "MainFeatures");
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
            return RedirectToAction("getAll", "MainFeatures");
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
                ci.AddClaim(new Claim(ClaimTypes.Name, user.CustomerId.ToString()));
                ClaimsPrincipal cp = new ClaimsPrincipal();
                cp.AddIdentity(ci);

                await HttpContext.SignInAsync(cp);

                return RedirectToAction("getAll", "MainFeatures");
            }
            return View(model);
        }

        public async Task<IActionResult> Profile(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

    }
}
