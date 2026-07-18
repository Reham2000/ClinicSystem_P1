using ClinicSystem.Application.Commen;
using ClinicSystem.Domain.DTos.Department;

namespace ClinicSystem.Application.InterFaces.Servecies
{
    public interface IDepartmentService
    {
        Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync();
        Task<Result<DepartmentDto>> GetByIdAsync(int id);
        Task<Result> CreateAsync(CreateDepartmentDto dto);
        Task<Result> UpdateAsync(UpdateDepartmentDto dto);
        Task<Result> DeleteAsync(int id);
        Task<Result> RestoreAsync(int id);
    }
}
