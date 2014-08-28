namespace Users.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Users.Data;
    using System.Transactions;
    
    class Demo
    {
        static void Main()
        {
            InsertUser("Bat Spinder");
        }

        public static void InsertUser(string name)
        {
            using (var scope = new TransactionScope())
            {
                using (var ctx = new UsersModelContainer())
                {
                    Groups adminGroup = new Groups { Name = "Admins" };
                    var cond = ctx.GroupsSet.Any(g => g.Name.CompareTo("Admins") > 0);
                    if (cond)
                    {
                        ctx.GroupsSet.Add(adminGroup);
                        ctx.SaveChanges();
                        scope.Complete();
                    }
                    else
                    {
                        if (ctx.UsersSet.Any(u => u.Name == name))
                        {
                            Console.WriteLine("User with name {0} already exists!", name);
                            scope.Dispose();
                        }

                        Groups currentgroup = ctx.GroupsSet
                                                    .Where(x => x.Name == "Piinyaci")
                                                    .First();

                        Users newUser = new Users()
                        {
                            Name = name,
                            Id = currentgroup.Id
                        };

                        ctx.UsersSet.Add(newUser);
                        ctx.SaveChanges();
                        scope.Complete();
                    }
                }
            }
        }
    }
}