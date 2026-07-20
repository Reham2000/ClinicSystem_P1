using ClinicSystem.Domain.DTos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.InterFaces.Servecies
{
    public interface IAccountService
    {
        Task<SignInResult> Login(LoginVM model);
        Task Logout();
    }
}
