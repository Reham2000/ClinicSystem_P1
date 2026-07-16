using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class Appontment : BaseEntity
    {
        [Required,DataType(DataType.Date)]
        public DateOnly Date { get; set; }
        [Required,DataType(DataType.Time)]
        public TimeOnly Time { get; set; }
        [MaxLength(300)]
        public string? Notes { get; set; }
        [Required]
        public int Status { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }


        public ICollection<AppoinmentPatientDetails> AppoinmentPatientDetails { get; set; } 
                                    = new List<AppoinmentPatientDetails>();
    }
}
