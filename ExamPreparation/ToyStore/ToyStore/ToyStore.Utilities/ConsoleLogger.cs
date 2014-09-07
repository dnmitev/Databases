namespace ToyStore.Utilities
{
    using System;
    using System.Linq;

    using ToyStore.Utilities.Contracts;
    
    public class ConsoleLogger : ILogger<string>
    {
        /// <summary>
        /// Logs on the console
        /// </summary>
        /// <param name="data">the info to be logged on the console</param>
        public void Log(string data)
        {
            Console.Write(data);
        }
    }
}