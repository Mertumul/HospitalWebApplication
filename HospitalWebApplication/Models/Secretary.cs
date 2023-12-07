using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Secretary : Employee
    {
        [Required(ErrorMessage = "Secretary experience is required.")]
        public short ScExperience { get; set; }
        public ICollection<Announcement> Announcements { get; set; } = null!;



    }
}
