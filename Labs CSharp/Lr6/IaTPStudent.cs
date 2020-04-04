using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    enum Specialtys
    {
        IaTP = 1,
        CSaN,
        ITS,
        ECS
    }

    public struct Discipline
    {
        public string DisciplineName { get; set; }
        public int Hours { get; set; }
    }


    class IaTPStudent:Student,IQualif,IComparable
    {
        

        public Specialtys Specialty { get; set; }
        public string GroupNumber { get; set; }
        public string Qualification { get; set; }
        public string Scholarship { get; set; }

        Discipline dis;

        public IaTPStudent() : base()
        {
            Specialty = Specialtys.IaTP;
            GroupNumber = "753503";
            dis.DisciplineName = "ISP";
            dis.Hours = 120;
            Qualification = "System Engineer";
            Scholarship = "77,80";
        }

        public override string ToString()
        {
            return base.ToString() + "Specialty: " + Specialty + ";" + "Group: " + GroupNumber + ";" + "Discipline: " + dis.DisciplineName + ";"+"\n" + "Hours for input discipline: " + dis.Hours+";"+"Qualification: "+Qualification+";"+"Scholarship: "+Scholarship+"\n";
        }


        public void SetParametrs()
        {
            Console.Write("Enter name: ");
            Name = Console.ReadLine();

            Console.Write("Enter age: ");
            Age = ValidateAge();

            Console.Write("Enter height in meters: ");
            HeightMeters = CheckDouble();

            Console.Write("Enter weight in kilograms: ");
            WeightKilos = CheckDouble();

            Console.Write("Enter city where he/her was born: ");
            CityBorn = Console.ReadLine();

            SetId();

            Console.Write("Enter faculty: ");
            Faculty = Console.ReadLine();

            Console.Write("Enter course: ");
            Course = CheckInt();

            Console.Write("Enter specialty(1-IaTP, 2-CSaN, 3-ITS, 4-ECS): ");
            Specialty = (Specialtys)ValidateSpeciality();

            Console.Write("Enter group number: ");
            GroupNumber = Console.ReadLine();

            Console.Write("Enter qualification: ");
            Qualification = Console.ReadLine();

            Console.Write("Enter discipline: ");
            dis.DisciplineName = Console.ReadLine();

            Console.Write("Enter hours for this discipline: ");
            dis.Hours = CheckInt();

            Console.Write("Enter scholarship: ");
            Scholarship = Console.ReadLine();
        }

        //добавленное в 6 лабораторной    
        public static void SetArray(IaTPStudent[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new IaTPStudent();
                list[i].SetParametrs();
                Console.WriteLine();
            }

            Console.WriteLine("List of stusents:");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        public override void DiplomaType()
        {
            Console.WriteLine("Your qualification is {0}",Qualification);
        }

        public override void SetScholarship()
        {
            Console.WriteLine($"Your scholarship is:  {Scholarship}");
        }
 
        int IComparable.CompareTo(object obj)
        {
            if (this.Age > ((IaTPStudent)obj).Course)
            {
                return 1;
            }
            if (this.Age < ((IaTPStudent)obj).Course)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
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
    }
}
