using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Harry", "Potter", "AA111111");
            var worker = new Worker("Arthur", "Weasley", "BB222222");
            var pensioner1 = new Pensioner("Albus", "Dumbledore", "CC333333");
            var pensioner2 = new Pensioner("Minerva", "McGonagall", "DD444444");

            var citizens = new Citizens();
            citizens.Add(worker);
            citizens.Add(pensioner1);
            citizens.Add(student);
            citizens.Add(pensioner2);
            citizens.Add(worker);

            Console.WriteLine(new string('-', 40));

            foreach (var citizen in citizens)
            {
                Console.WriteLine(citizen);
            }

            Console.WriteLine(new string('-', 40));

            Console.ReadKey();
        }
    }
}
