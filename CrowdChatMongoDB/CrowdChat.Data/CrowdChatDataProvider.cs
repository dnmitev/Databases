namespace CrowdChat.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CrowdChat.Models;

    using MongoRepository;

    public class CrowdChatDataProvider
    {
        private readonly IDictionary<Type, object> repositories;

        public CrowdChatDataProvider()
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public MongoRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public MongoRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        private MongoRepository<T> GetRepository<T>() where T : Entity
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(MongoRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type));
            }

            return (MongoRepository<T>)this.repositories[typeOfModel];
        }
    }
}