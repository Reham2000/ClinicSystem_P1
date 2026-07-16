using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        [Required,MaxLength(200)]
        public string Spisalization {  get; set; }
        [Required]
        public decimal Fee { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public byte[] ImageBytes { get; set; }
        // User Data
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        // department
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Appontment> Appontments { get; set; } = new List<Appontment>();
    }
}
