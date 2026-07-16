using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Domain.Entities
{
    public class User : IdentityUser

    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        public char Gender { get; set; }
    }
}
