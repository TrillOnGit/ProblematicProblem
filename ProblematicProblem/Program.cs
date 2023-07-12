using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ProblematicProblem
{
    internal abstract class Program
    {
        private static Random _rng = new Random();
        static bool _cont = true;

        public static List<string> Activities = new()
            { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write(
                "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            _cont = UserWant();
            if (!_cont)
            {
                Environment.Exit(0);
            }
            Console.WriteLine();
            
            Console.Write("We are going to need your information first! What is your name? "); 
            var userName = Console.ReadLine();
            Console.WriteLine();
            
            Console.Write("What is your age? ");
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.WriteLine("Please input a valid number");
            }
            Console.WriteLine();
            
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            var seeList = UserWant(); 
            if (seeList)
            {
                foreach (var activity in Activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = UserWant();
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    Activities.Add(userAddition);
                    foreach (string activity in Activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = UserWant();
                }
            }

            while (_cont)
            {
                Console.Write("Connecting to the database");
        
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(5 //00);
                    );
                }

                Console.WriteLine(); 
                Console.Write("Choosing your random activity");
        
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(5 //00);
                    );
                }

                Console.WriteLine();
                int randomNumber = _rng.Next(Activities.Count()); 
                    
                string randomActivity = Activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    Activities.Remove(randomActivity);
                    randomNumber = _rng.Next(0, Activities.Count());
                    randomActivity = Activities[randomNumber];
                }

                Console.Write(
                    $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo?");
                Console.WriteLine();
                _cont = UserWant();
            }
        }

        private static bool UserWant()
        {
            var userState = Console.ReadLine();

            if (userState == null) return false;
            switch (userState.ToLower())
            {
                case "yes" or "sure" or "y" or "yeah" or "true" or "redo":
                    return true;
                case "no" or "no thanks" or "n" or "nah" or "false" or "keep":
                    return false;
                default:
                    Console.WriteLine("Invalid input, assuming no.");
                    return false;
            }
        }
    }
}