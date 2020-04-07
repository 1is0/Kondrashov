using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class Program
    {

        public static void SetParametrs(CompetenciesPerson obj)
        {
            Console.Write("Enter name: ");
            obj.Name = Console.ReadLine();

            Console.Write("Enter age: ");
            obj.Age = ValidateAge();

            Console.Write("Enter height in meters: ");
            obj.HeightMeters = CheckDouble();

            Console.Write("Enter weight in kilograms: ");
            obj.WeightKilos = CheckDouble();

            Console.Write("Enter city where he/her was born: ");
            obj.CityBorn = Console.ReadLine();

            obj.SetId();

            Console.Write("Enter faculty: ");
            obj.Faculty = Console.ReadLine();

            Console.Write("Enter course: ");
            obj.Course = CheckInt();

            Console.Write("Enter specialty(1-IaTP, 2-CSaN, 3-ITS, 4-ECS): ");
            obj.Specialty = (SpecialtyName)ValidateSpeciality();

            Console.Write("Enter group number: ");
            obj.GroupNumber = Console.ReadLine();

            Console.Write("Enter qualification: ");
            obj.Qualification = Console.ReadLine();

            Console.Write("Enter discipline: ");
            obj.dis.DisciplineName = Console.ReadLine();

            Console.Write("Enter hours for this discipline: ");
            obj.dis.Hours = CheckInt();
        }

        public static int ValidateSpeciality()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result < 1 || result > 4)
            {
                Console.Write("Incorrect input, please try again: ");
            }

            return result;
        }

        public static int ValidateAge()
        {
            int vozrast;
            while (!int.TryParse(Console.ReadLine(), out vozrast) || vozrast <= 15)
            {
                Console.Write("Incorrect age input, please try again: ");
            }

            return vozrast;
        }

        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Incorrect input, please try again: ");
            }

            return a;
        }

        public static double CheckDouble()
        {
            double b;
            while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.Write("Incorrect input, please try again: ");
            }

            return b;
        }

        static void Main()
        {
            CompetenciesPerson std = new CompetenciesPerson();

            Console.WriteLine("Info about default student : ");
            Console.WriteLine(std);
            Console.WriteLine("\n");

            SetParametrs(std);
            Console.WriteLine();

            std.DiplomaType();
            Console.WriteLine();
            Console.WriteLine(std);
            Console.WriteLine();

            std.MassIndex();

            Console.ReadKey();
        }
    }
}
