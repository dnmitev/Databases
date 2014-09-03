namespace CrowdChat.Models
{
    using System;
    using System.Linq;

    using MongoRepository;

    public class Message : Entity
    {
        public Message(string text, DateTime date, User username)
        {
            this.Text = text;
            this.Date = date;
            this.Username = username;
        }

        public Message()
        {
        }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public User Username { get; set; }
    }
}