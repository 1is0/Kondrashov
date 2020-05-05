using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class MainProg
    {

        public static void SetParameters(CompetenciesPerson obj)
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

            Console.Write("Enter scholarship: ");
            obj.Scholarship = Console.ReadLine();
        }

        //добавленное в 6 лабораторной    
        public static void SetArray(CompetenciesPerson[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new CompetenciesPerson();
                SetParameters(list[i]);
                Console.WriteLine();
            }

            Console.WriteLine("List of stusents:");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        //Проверки на ввод
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
            try
            {
                Console.WriteLine(std);
            }
            catch(Exception ex)
            {
                Console.WriteLine("\nException testing: "+ex.Message+"\n");
            }
            Console.WriteLine("\n");
            //добавленное в 8 лабораторной

            std.StudentInfo += DisplayInfo;
            std.SetId();


            Console.WriteLine("Type info for new students:");
            CompetenciesPerson[] list = new CompetenciesPerson[2];
            SetArray(list);
            Console.WriteLine();
            for (int j = 0; j < list.Length; j++)
            {
                list[j].MassIndex();
                Console.WriteLine("Event tested: ");
                list[j].StudentInfo += delegate (string mes)
                {
                    Console.WriteLine("Anonim expression: " + mes);
                };
                
                list[j].StudentInfo += mes => Console.WriteLine("Lambda expression: " + mes);
                Console.WriteLine();
                list[j].SetId();
            }

            Console.WriteLine();
            Console.WriteLine("Sorted by course list:");
            Array.Sort(list);
            foreach (CompetenciesPerson s in list)
            {
                Console.WriteLine(s);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Copy of the first student in the list:");
            CompetenciesPerson obj = (CompetenciesPerson)list[0].Clone();
            Console.WriteLine(obj);

            IStudentAttributes action2 = new CompetenciesPerson();
            Student action1 = new Student();
            Console.WriteLine();
            action1.DiplomaType();
            action2.DiplomaType();

            action1.SetScholarship();
            action2.SetScholarship();

            Console.WriteLine();

            Console.ReadKey();
        }

        public static void DisplayInfo(string mes)
        {
            Console.WriteLine("Event: "+mes);
        }

    }
}
