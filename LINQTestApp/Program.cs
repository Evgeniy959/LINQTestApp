using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTestApp
{
    class Program
    {
        static void Main()
        {
            /*var array = new ListUser
            {
                Users = new List<User>
                {
                    new() { Name = "First", Age = 10, Languages = new List<string> { "russian", "english" } },
                    new() { Name = "Second", Age = 10, Languages = new List<string> { "russian", "deutsch" } },
                    new() { Name = "Last", Age = 20, Languages = new List<string> { "english", "deutsch" } },
                    new() { Name = "Lost", Age = 20, Languages = new List<string> { "english", "deutsch" } },
                    new() { Name = "deutsch", Age = 20, Languages = new List<string> { "deutsch", "deutsch" } }
                }
            };

            ShowCollection(array.Users);

            var list = from user in array.Users
                       from language in user.Languages
                       where language == "deutsch"
                       where user.Age == 10
                       select user;

            var collection = new ListUser(list);
            ShowCollection(collection.Users);

            array.Users[1].Age = 20;
            array.Users[1].Languages[1] = "russian";
            ShowCollection(collection.Users);
        }*/
            var array = new List<User>
            {
                new() { Name = "First", Age = 10, Languages = new List<string> { "russian", "english" } },
                new() { Name = "Second", Age = 10, Languages = new List<string> { "russian", "deutsch" } },
                new() { Name = "Last", Age = 20, Languages = new List<string> { "english", "deutsch" } },
                new() { Name = "Lost", Age = 20, Languages = new List<string> { "english", "deutsch" } },
                new() { Name = "deutsch", Age = 20, Languages = new List<string> { "deutsch", "deutsch" } }
            };

            ShowCollection(array);

            var list = from user in array
                       from language in user.Languages
                       where language == "deutsch"
                       where user.Age == 10
                       select user;

            var collection = new ListUser(list);
            ShowCollection(collection.Users);            

            array[1].Age = 20;
            array[1].Languages[1] = "russian";
            ShowCollection(collection.Users);
            ShowCollection(array);
        }
            static void ShowCollection(IEnumerable<User> collection)
        {
            Console.WriteLine();
            foreach (var user in collection)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{user.Name}, {user.Age}\t");

                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var language in user.Languages)
                {
                    Console.Write($"{language},\t");
                }

                Console.ResetColor();
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }

        public User Copy()
        {
            var user = new User
            {
                Name = new string(Name),
                Age = Age,
                Languages = new List<string>()
            };

            foreach (var language in Languages)
            {
                user.Languages.Add(language);
            }

            return user;
        }
    }

    public class ListUser
    {
        public List<User> Users;

        public ListUser()
        {
            Users = new List<User>();
        }

        public ListUser(IEnumerable<User> users)
        {
            Users = new List<User>();
            foreach (var user in users)
            {
                Users.Add(user.Copy());
            }
        }
    }    
}
