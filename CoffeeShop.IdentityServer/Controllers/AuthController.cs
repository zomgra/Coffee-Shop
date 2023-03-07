using CoffeeShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel() { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var res = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if(!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
            
                return View(model);
            }
            return Redirect(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var model = new RegisterViewModel() { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect(model.ReturnUrl);
        }
    }
}
