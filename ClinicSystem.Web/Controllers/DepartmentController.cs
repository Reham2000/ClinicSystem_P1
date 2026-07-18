using AspNetCoreGeneratedDocument;
using ClinicSystem.Application.InterFaces.Servecies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicSystem.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _departmentService.GetAllAsync();
            if (result.IsSuccessed)
            {

                var departments = result.Data;
                return View(departments);
            }
            return View(nameof(Views_Shared__404));
        }
    }
}
