using System;
//use lists
using System.Collections.Generic;

namespace LearnLists
{
    class Program
    {
        static void Main()
        {
            //Create an empty list of type double
            List<double> marathons = new List<double>();

            // Add() statements to add those values to the list.
            marathons.Add(144.07);
            marathons.Add(143.12);

            // access elements using indices and square brackets:
            Console.WriteLine(marathons[0]);
            Console.WriteLine(marathons[1]);

            //list with an object initialization.
            List<double> marathons2 =
                new List<double> { 144.08, 143.13, 146.73, 146.33 };

            double time = marathons2[1];

            Console.WriteLine($"The 2012 marathon was ran in {time} minutes!");

            //Count how many items in the list
            Console.WriteLine(marathons2.Count);
            marathons2.Add(143.33);

            //check if an element exists in a list,return bool
            Console.WriteLine(marathons2.Contains(143.33));
            Console.WriteLine(marathons2.Count);

            Console.WriteLine(marathons[1]);

            //to remove a specific item from a list,return bool
            bool removed = marathons.Remove(143.12);
            Console.WriteLine (removed);
            Console.WriteLine(marathons[1]);

            // Clear the list here,remove all the items
            marathons.Clear();
            Console.WriteLine($"Count: {marathons.Count}");

            //GetRange(startIndex,numOfIndex) to get the first three elements
            List<double> topMarathons = marathons.GetRange(0, 3);

            //loop to iterate over every double in the topMarathons
            foreach (double d in topMarathons)
            {
                Console.WriteLine (d);
            }

            List<string> runners =
                new List<string> {
                    "Jemima Sumgong",
                    "Tiki Gelana",
                    "Constantina Tomescu",
                    "Mizuki Noguchi"
                };
            Random rand = new Random();

            Console
                .WriteLine("In reverse chronological order, the gold medalists are...");

            // For loop
            for (int i = 0; i < runners.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {runners[i]}");
            }

            Console.WriteLine("\nPrinting runner bibs...");

            //foreach loop
            foreach (string i in runners)
            {
                string name = i.ToUpper();
                int id = rand.Next(100, 1000);
                Console.WriteLine($"{id} - {name}");
            }

            //Declare three empty lists:
            List<bool> b = new List<bool>();
            List<Random> r = new List<Random>();
            List<IServiceProvider> i = new List<IServiceProvider>();
        }
    }
}
