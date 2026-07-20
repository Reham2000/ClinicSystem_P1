using AspNetCoreGeneratedDocument;
using ClinicSystem.Application.InterFaces;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos.Doctors;
using ClinicSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ClinicSystem.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorservice _doctorService;
        public DoctorController(IDoctorservice doctorservice,IUnitOfWork unitOfWork)
        {
            _doctorService = doctorservice;
            _unitOfWork = unitOfWork;
        }
        private async Task LoadDepartments(int? selectedItem = null)
        {
            var deptRepo = _unitOfWork.Reposatory<Department>();
            var departments = await deptRepo.GetAllAsync();
            ViewBag.departments = new SelectList(departments, "Id", "Name",selectedItem);
        }
        public async Task<IActionResult> Index()
        {
            var Doctors = await _doctorService.GetAllAsync();
            if(Doctors.IsSuccessed)
                return View(Doctors.Data);
            return View(nameof(Views_Shared__404));
        }

        public async Task<IActionResult> Create()
        {
            await LoadDepartments();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorDto dto)
        {
            await LoadDepartments();
            if(! ModelState.IsValid)
                return View(dto);

            var result = await _doctorService.CreateAsync(dto);
            if (result.IsSuccessed)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = result.Message;
            if(result.Errors != null)
            {
                ViewBag.Errors = result.Errors;

                TempData["Erros"] = System.Text.Json.JsonSerializer.Serialize(result.Errors);
            }
            return View(dto);
        }
    }
}
