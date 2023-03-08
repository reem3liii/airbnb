using airbnb.DTO;
using airbnb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace airbnb.Controllers
{
    //[Route("api/")]
    //[ApiController]
    //public class UsersController : ControllerBase
    public class UsersController : Controller
    {
        private readonly AirbnbDbContext _context;

        public UsersController(AirbnbDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO user)
        {
            Customer customer = _context.Customers.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();

            if (customer != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("airbnb_key_123456"));

                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                 expires: DateTime.Now.AddMinutes(120),
                 signingCredentials: credentials);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return Unauthorized();    

            }
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDTO user)
        {
            var customer = new Customer() {
                FirstName=user.FirstName, LastName =user.LastName,DOB=user.DOB, Email= user.Email, Password= user.Password };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("airbnb_key_123456"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
             expires: DateTime.Now.AddMinutes(120),
             signingCredentials: credentials);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        }
}
