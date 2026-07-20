using AutoMapper;
using ClinicSystem.Application.Commen;
using ClinicSystem.Application.InterFaces;
using ClinicSystem.Application.InterFaces.Servecies;
using ClinicSystem.Domain.DTos.Department;
using ClinicSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Result<DepatmentDetailsDto>> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Reposatory<Department>();
            //var department = await repo.FindAsync(d => d.Id == id,d => d.Doctors);
            var department = await repo.FindAsync(
                d => d.Id == id,
                query => query.Include(d => d.Doctors ).ThenInclude(doc => doc.User)

                );
            var result = _mapper.Map<DepatmentDetailsDto>(department);
            return Result<DepatmentDetailsDto>.Success(data: result);
        }
        public async Task<Result> CreateAsync(CreateDepartmentDto dto)
        {
            var repo = _unitOfWork.Reposatory<Department>();
            var data = _mapper.Map<Department>(dto);
            await repo.AddAsync(data);
            if (await _unitOfWork.CompleteAsync() > 0)
                return Result.Success();
            return Result.Faild("Department doesn't added");
        }

        public Task<Result> DeleteAsync(int id)
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
