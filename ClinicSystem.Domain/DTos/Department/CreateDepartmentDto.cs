using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Domain.DTos.Department
{
    public class CreateDepartmentDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
