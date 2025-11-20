using System;
using System.ComponentModel.DataAnnotations;

namespace StudentNotification.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }=DateTime.Now;

        public Student? Student { get; set; }
    }
}
