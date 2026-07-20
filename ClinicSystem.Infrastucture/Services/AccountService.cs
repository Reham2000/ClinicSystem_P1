using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos;
using ClinicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Infrastucture.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Login(LoginVM model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.UserName, model.Password, model.RememberMe, false);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
