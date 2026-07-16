using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        // create
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        // Update
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        // softDelete
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get;set; }
    }
}
