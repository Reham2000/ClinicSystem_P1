using AutoMapper;
using ClinicSystem.Application.Commen;
using ClinicSystem.Application.InterFaces;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos.Department;
using ClinicSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Infrastucture.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<DepartmentDto>>> GetAllAsync()
        {
            // repo = _unitOfWork.Departments
            var repo =  _unitOfWork.Reposatory<Department>();
            var departments = await repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return Result<IEnumerable<DepartmentDto>>.Success(data: result);
        }

        public Task<Result> CreateAsync(CreateDepartmentDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Result<DepartmentDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> RestoreAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateAsync(UpdateDepartmentDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
