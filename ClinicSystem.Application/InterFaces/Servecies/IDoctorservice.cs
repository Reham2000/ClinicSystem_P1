using ClinicSystem.Application.Commen;
using ClinicSystem.Domain.DTos.Department;
using ClinicSystem.Domain.DTos.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.InterFaces.Servecies
{
    public interface IDoctorservice
    {
        Task<Result<IEnumerable<DoctorDto>>> GetAllAsync();
        //Task<Result<DepatmentDetailsDto>> GetByIdAsync(int id);
        Task<Result> CreateAsync(CreateDoctorDto dto);
        //Task<Result> UpdateAsync(UpdateDepartmentDto dto);
        //Task<Result> DeleteAsync(int id);
        //Task<Result> RestoreAsync(int id);
    }
}
