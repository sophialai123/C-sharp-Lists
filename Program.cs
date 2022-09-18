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
        }
    }
}
