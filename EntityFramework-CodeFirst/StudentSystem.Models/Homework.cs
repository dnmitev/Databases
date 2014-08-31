namespace StudentSystem.Models
{
    using System;
    using System.Linq;

    public class Homework
    {
        public Homework()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime Deadline { get; set; }

        public DateTime TimeSent { get; set; }

        public string FileName { get; set; }
    }
}