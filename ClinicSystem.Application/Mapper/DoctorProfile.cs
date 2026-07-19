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
        }
    }
}
