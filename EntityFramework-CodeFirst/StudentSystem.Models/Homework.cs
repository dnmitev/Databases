namespace StudentSystem.Models
{
    using System;
    using System.Linq;

    public class Homework
    {
        private DateTime deadline;
        private DateTime timeSent;

        public Homework()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime Deadline
        {
            get
            {
                return DateTime.Parse(this.deadline.ToString());
            }

            set
            {
                this.deadline = value;
            }
        }

        public DateTime TimeSent
        {
            get
            {
                return DateTime.Parse(this.timeSent.ToString());
            }

            set
            {
                this.timeSent = value;
            }
        }

        public string FileName { get; set; }
    }
}