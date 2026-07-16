using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class Patient : BaseEntity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateOnly DOB {  get; set; }
        [MaxLength(300),Required]
        public string Address { get; set; }

        public ICollection<Appontment> Appontments { get; set; } = new List<Appontment>();
    }
}
