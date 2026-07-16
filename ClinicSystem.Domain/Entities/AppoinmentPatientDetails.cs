using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class AppoinmentPatientDetails 
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(300)]
        public string Medicne { get; set; }
        [Required,MaxLength(300)]
        public string Description { get; set; }
        [ForeignKey(nameof(Appontment))]
        public int AppoinmentId { get; set; }
        public Appontment Appontment { get; set; }
    }
}
