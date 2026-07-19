using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Domain.DTos.Doctors
{
    public class CreateDoctorDto
    {
        // user
        [Required]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required]
        public char? Gender { get; set; } = 'M';
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("^[^\\s@]+@([^\\s@.,]+\\.)+[^\\s@.,]{2,}$")]
        public string Email { get; set; }
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        // doctor
        [Required, MaxLength(200)]
        public string Spisalization { get; set; }
        [Required]
        public decimal Fee { get; set; }

        [Required]
        public IFormFile FormFile { get; set; } 
        public int DepartmentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        
    }
}
