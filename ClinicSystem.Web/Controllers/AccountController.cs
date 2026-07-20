using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _accountService.Login(model);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index), "Home");

            ModelState.AddModelError("UserName", "Invalid UserName or Password");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction(nameof(Login) );
        }
    }
}
