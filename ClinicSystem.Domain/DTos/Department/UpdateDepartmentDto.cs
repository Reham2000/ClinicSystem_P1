using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Domain.DTos.Department
{
    public class UpdateDepartmentDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
