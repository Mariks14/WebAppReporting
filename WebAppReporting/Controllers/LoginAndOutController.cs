using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppReporting.Models.EFContext;

namespace WebAppReporting.Controllers
{
    public class LoginAndOutController : Controller
    {

        private ApplicationContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly List<Person> _people;


        public LoginAndOutController(ILogger<HomeController> logger, ApplicationContext context, List<Person> people)
        {
            _context = context;
            _logger = logger;
            _people = people;
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string Login, string Password)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            Person? person = _people.FirstOrDefault(p => p.Name == Login && p.Password == Password);

            if (person is null) return View();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Name) };
            // создаем объект ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");

        }
    }
}
