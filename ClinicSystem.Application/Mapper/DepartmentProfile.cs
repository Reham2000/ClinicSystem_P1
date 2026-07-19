using AutoMapper;
using ClinicSystem.Domain.DTos.Department;
using ClinicSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.Mapper
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            // Entity => DTO
            CreateMap<Department, DepartmentDto>();
            // create dto => entity
            CreateMap<CreateDepartmentDto, Department>();
            // Update dto => entity
            CreateMap<UpdateDepartmentDto, Department>();
            // entity => update dto
            CreateMap<Department, UpdateDepartmentDto>();
            CreateMap<Department, DepatmentDetailsDto>();
        }
    }
}
