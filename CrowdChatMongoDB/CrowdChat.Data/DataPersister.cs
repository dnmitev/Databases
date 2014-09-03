using CrowdChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdChat.Data
{
    public class DataPersister
    {
        private CrowdChatDataProvider data;

        public DataPersister()
            : this(new CrowdChatDataProvider())
        {
        }

        public DataPersister(CrowdChatDataProvider data)
        {
            this.data = new CrowdChatDataProvider();
        }

        /// <summary>
        /// Register new username to the MongoDB
        /// </summary>
        /// <param name="username">String value as the nickname</param>
        public void RegisterUser(string username)
        {
            data.Users.Add(new User(username));
        }

        /// <summary>
        /// Retrieves the last stored user as current
        /// </summary>
        /// <returns>User object to represent the last stored user in the DB</returns>
        public User GetCurrentUser()
        {
            return data.Users.AsEnumerable<User>().LastOrDefault();
        }

        /// <summary>
        /// Retrieve all messages within their data from the MongoDB 
        /// </summary>
        /// <returns>IQueryble object</returns>
        public IQueryable<Message> GetAllMessages()
        {
            return data.Messages.AsQueryable();
        }

        public void SendMessage(User user, string message)
        {
            this.data.Messages.Add(new Message(message, DateTime.Now, user));
        }
    }
}
