using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Staff : Employee
    {
        [Required(ErrorMessage = "Secretary experience is required.")]
        public short StExperience { get; set; }
    }
}
