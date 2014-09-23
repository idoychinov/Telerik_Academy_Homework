namespace BugLogger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime LogDate { get; set; }

        public Status Status { get; set; }
    }
}
