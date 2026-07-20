using AutoMapper;
using ClinicSystem.Domain.DTos.Doctors;
using ClinicSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Application.Mapper
{
    public class DoctorProfile :Profile
    {
        public DoctorProfile()
        {
            CreateMap<CreateDoctorDto, Doctor>();
            CreateMap<Doctor, CreateDoctorDto>();


            CreateMap<Doctor, DoctorDto>()
                .ForMember(d => d.DepartmentName, v => v.MapFrom(dep => dep.Department.Name))
                .ForMember(d => d.FullName, v => v.MapFrom(d => d.User.FullName))
                .ForMember(d => d.UserName, v => v.MapFrom(d => d.User.UserName))
                .ForMember(d => d.Email, v => v.MapFrom(d => d.User.Email))
                .ForMember(d => d.Gender, v => v.MapFrom(d => d.User.Gender));


            
        }
    }
}
