namespace CrowdChat.ConsoleClient
{
    using CrowdChat.Data;
    using CrowdChat.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main()
        {
            var data = new DataPersister();

            Console.WriteLine("User:");
            string username = Console.ReadLine();

            data.RegisterUser(username);

            var msgs = data.GetAllMessages();

            Console.WriteLine(msgs.AsEnumerable<Message>().First().Text);
        }
    }
}