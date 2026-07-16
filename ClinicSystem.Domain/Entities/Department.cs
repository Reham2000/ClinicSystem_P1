using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }


        public ICollection<Doctor> Doctors {  get; set; } = new List<Doctor>();
    }
}
