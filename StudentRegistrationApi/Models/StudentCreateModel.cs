using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationApi.Models
{
    public class StudentCreateModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Nic { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        public IFormFile ProfilePicture { get; set; } // Represents the uploaded file
        public string ImgPath { get; set; } // This will store the file path in the server
    }
}
