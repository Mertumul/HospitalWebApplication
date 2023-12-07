using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApplication.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }

        [ForeignKey("Secretary")]
        [Required(ErrorMessage = "Person ID is required.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Announcement content is required.")]
        public string AnnouncementContent { get; set; } = null!;

        [Required(ErrorMessage = "Announcement date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        // Navigation property
        public Secretary Secretary { get; set; } = null!;
    }
}
