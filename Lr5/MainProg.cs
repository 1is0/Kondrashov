using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class Program
    {
        static void Main()
        {
            IaTPStudent std = new IaTPStudent();

            Console.WriteLine("Info about default student : ");
            Console.WriteLine(std);
            Console.WriteLine("\n");

            std.SetParametrs();
            Console.WriteLine();

            std.DiplomaType();
            Console.WriteLine(std);
            Console.WriteLine();

            std.MassIndex();

            Console.ReadKey();
        }
    }
}
