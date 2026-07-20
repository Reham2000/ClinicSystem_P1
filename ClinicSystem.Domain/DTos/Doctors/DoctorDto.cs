using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.DTos.Doctors
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phonenumber { get; set; }
        public char Gender { get; set; }
        public string Spisalization { get; set; }
        public decimal Fee { get; set; }
        public string DepartmentName { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
