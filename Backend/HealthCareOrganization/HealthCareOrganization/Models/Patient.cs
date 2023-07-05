using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCareOrganization.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }


        [Required(ErrorMessage = "Name cannot be empty")]
        public string? PatientName { get; set; }
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Age Cannot be Null")]
        public int Age { get; set; }
        public string? Affliction { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Gender cannot be empty")]
        public string Gender { get; set; }
        public string? PhoneNo { get; set; }

    }
}
