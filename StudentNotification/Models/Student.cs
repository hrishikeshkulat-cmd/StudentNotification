using System.ComponentModel.DataAnnotations;

namespace StudentNotification.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage ="Name should not be empty!")]
        public string Name { get; set; }= string.Empty;

        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}
