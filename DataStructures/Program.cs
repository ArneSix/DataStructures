using System;
using DataStructures.structures;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> list = new DynamicArray<int>();
            list.Add(15);
            list.Add(10);
            list.Add(5);
            list.Add(15);
            list.Add(10);
            list.Add(5);
            list.Add(15);
            list.Add(10);
            list.Add(5);
            list.Add(15);
            list.Add(10);
            list.Add(5);
            list.Add(15);
            list.Add(10);
            list.Add(5);
            Console.WriteLine($"Length is: {list.Length}");
            Console.WriteLine($"Size is: {list.Size}");
            list.Add(6);
            list.Add(6);
            Console.WriteLine($"Length is: {list.Length}");
            Console.WriteLine($"Size is: {list.Size}");

            foreach (var value in list)
            {
                Console.WriteLine(value);
            }
        }
    }
}
