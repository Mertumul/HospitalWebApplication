using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Secretary
    {
        [Key]
        public int SecretarytId { get; set; }

        [Required(ErrorMessage = "TC Identification Number is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Identification Number must be 11 characters.")]
        public string TCIdentificationNo { get; set; } = null!;

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; } = null!;

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "Gender must be a single character.")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public short Age { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Criminal record is required.")]
        public int CriminalRecord { get; set; }

        public ICollection<Announcement> Announcements { get; set; } = null!;



    }
}
