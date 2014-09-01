namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
 
    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime TimeSent { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0}, Content: {1}, Sent by: {2}, For Course: {3}, Sent at: {4} ", this.Id, this.Content, this.Student.Name, this.Course.Name, this.TimeSent);
        }
    }
}
