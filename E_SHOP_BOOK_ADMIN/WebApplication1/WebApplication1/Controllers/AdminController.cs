using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly string predefinedUsername = "admin";
        private readonly string predefinedPassword = "Admin@123";

        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            _logger.LogInformation("Login method reached");
            _logger.LogInformation($"Username: {username}, Password: {password}");

            if (username == predefinedUsername && password == predefinedPassword)
            {
                _logger.LogInformation("Login successful.");

                // Create user claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin") // Add role for future use
                };

                // Create the identity
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create the principal
                var principal = new ClaimsPrincipal(identity);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Order");
            }

            _logger.LogWarning("Invalid login attempt.");
            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logging out admin");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
