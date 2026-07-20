using AutoMapper;
using ClinicSystem.Application.Commen;
using ClinicSystem.Application.InterFaces;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos.Doctors;
using ClinicSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;



namespace ClinicSystem.Infrastucture.Services
{
    public class DoctorService : IDoctorservice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IWebHostEnvironment _webHost;
        public DoctorService(IUnitOfWork unitOfWork,UserManager<User> userManager
            ,IMapper mapper , RoleManager<IdentityRole> roleManager
            ,IWebHostEnvironment webHost
            )
        {
            _unitOfWork = unitOfWork;   
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _webHost = webHost;
        }
        public async Task<Result<IEnumerable<DoctorDto>>> GetAllAsync()
        {
            var repo = _unitOfWork.Reposatory<Doctor>();
            var doctors = await repo.GetAllAsync(
                d => d.User,
                d => d.Department
                );
            var result = _mapper.Map<IEnumerable<DoctorDto>>( doctors );
            return Result<IEnumerable<DoctorDto>>.Success(result);
        }
        public async Task<Result> CreateAsync(CreateDoctorDto dto)
        {
            var doctorRepo =  _unitOfWork.Reposatory<Doctor>();
            var DepartmentRepo =  _unitOfWork.Reposatory<Department>();
            // check email
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
                return Result.Faild("Email Aleady exists");
            // check username
            if (await _userManager.FindByNameAsync(dto.UserName) != null)
                return Result.Faild("UserName Already exist");
            // check department is exist
            var department = await DepartmentRepo.FindAsync(dto.DepartmentId);
            if (department == null)
                return Result.Faild("Department Not Found");

            // check if doctor already exist

            bool exists = await doctorRepo.ExistsAsync(d => d.User.FullName == dto.FullName
            && d.Spisalization == dto.Spisalization);
            if (exists)
                return Result.Faild("Doctor Already Exsit");


            // begien transaction
            await _unitOfWork.BeginTransactionAsync();
                string fileName = "";
                string imagePath = "";
                byte[] imageBytes = Array.Empty<byte>();    
            try
            {
                // Save Image


                if(dto.FormFile  != null)
                {
                    var extention = Path.GetExtension(dto.FormFile.FileName);
                    fileName = $"{Guid.NewGuid()}{extention}";// cgnfxnfgd565yd5.png
                    var folder = Path.Combine(_webHost.WebRootPath, "Uploads", "Doctors");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);
                    imagePath = Path.Combine(folder, fileName);
                    // bytes
                    using(var ms = new MemoryStream())
                    {
                        await dto.FormFile.CopyToAsync(ms);
                        imageBytes = ms.ToArray();
                    }
                    using(var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await dto.FormFile.CopyToAsync(stream);
                    }
                }
                // create User with hash password
                var user = new User
                {
                    FullName = dto.FullName,
                    Gender = dto.Gender ?? 'M',
                    UserName = dto.UserName,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                var identityResult = await _userManager.CreateAsync(user, dto.Password);
                if(! identityResult.Succeeded)
                {
                    if (File.Exists(imagePath))
                    { File.Delete(imagePath); }

                    await _unitOfWork.RollbackTransactionAsync();
                    return Result.Faild(identityResult.Errors.Select(e => e.Description).ToList()
                        , "Failed while create Doctor User");
                }
                // assign doctor role
                if(! await _roleManager.RoleExistsAsync("Doctor"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Doctor"));
                }
                var roleResult = await _userManager.AddToRoleAsync(user, "Doctor");

                if(! roleResult.Succeeded)
                {
                    if (File.Exists(imagePath))
                    { File.Delete(imagePath); }
                    await _unitOfWork.RollbackTransactionAsync();
                    return Result.Faild(
                        roleResult.Errors.Select(e => e.Description).ToList(),
                        "Failed while Assign role");
                }
                // create doctor
                var doctor = new Doctor
                {
                    UserId = user.Id,
                    DepartmentId = department.Id,
                    Spisalization = dto.Spisalization,
                    Fee = dto.Fee,
                    Image = fileName,
                    ImageBytes = imageBytes,
                    CreatedBy = dto.CreatedBy,
                    CreatedAt = DateTime.Now
                };
                await doctorRepo.AddAsync(doctor);

                // save
                await _unitOfWork.CompleteAsync();
                // commit
            await _unitOfWork.CommitTransactionAsync();
                return Result.Success("Doctor Created Successfully");
            }
            catch (Exception ex)
            {
                if (File.Exists(imagePath))
                { File.Delete(imagePath); }

                await _unitOfWork.RollbackTransactionAsync();
                return Result.Faild(new() {ex.Message} ,"Create Doctor Failed");
            }
            // return result
        }
    }
}
