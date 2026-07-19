using AspNetCoreGeneratedDocument;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos.Department;
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
        public async Task<IActionResult> Details(int id)
        {
            var result = await _departmentService.GetByIdAsync(id);
            if (result.IsSuccessed)
            {
                var data = result.Data;

                return View(data);
            }
            return View(nameof(Views_Shared__404));
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto dto)
        {
            if(! ModelState.IsValid)
            {
                return View(dto);
            }
            var result = await _departmentService.CreateAsync(dto);
            if (result.IsSuccessed)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }
    }
}
