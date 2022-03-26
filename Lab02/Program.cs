using System;
using System.Collections.Generic;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new(1, 3);
            Fraction fraction2 = new(1, 2);
            Fraction fraction3 = new(1, 6);

            Console.WriteLine(fraction1 + fraction2);
            Console.WriteLine(fraction1 -  fraction2);
            Console.WriteLine(fraction1 * fraction2);
            Console.WriteLine(fraction1 / fraction2);

            List<Fraction> list = new();
            list.Add(fraction1);
            list.Add(fraction2);
            list.Add(fraction3);

            Console.WriteLine("List before sorting");
            list.Sort();
            Console.WriteLine("List after sorting");
            list.ForEach(Console.WriteLine);
        }
    }
}
