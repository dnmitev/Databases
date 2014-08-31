namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Models;

    internal class Client
    {
        private static void Main()
        {
            var data = new StudentSystemData();

            data.Homeworks.Add(new Homework
            {
                FileName = "Domestic rakia",
                Deadline = new DateTime(2014, 08, 31)
            });

            data.Students.Add(new Student
            {
                FirstName = "Pesho",
                LastName = "Piandeto",
                PhoneNumber = "082569875"
            });

            data.Courses.Add(new Course
            {
                Name = "Kukuruz seller",
                Description = "Corn, corn, corn"
            });

            data.SaveChanges();
        }
    }
}