namespace CrowdChat.Models
{
    using System;
    using System.Linq;

    using MongoRepository;

    public class User : Entity
    {
        private string username;

        public User(string username)
        {
            this.Username = username;
        }

        public User()
        {
        }

        public string Username
        {
            get
            {
                return this.username.Trim();
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The username cannot be null or empty.");
                }

                if (value.Trim().Length < 3)
                {
                    throw new FormatException("Username should be at least 3 symbols long.");
                }

                this.username = value;
            }
        }
    }
}