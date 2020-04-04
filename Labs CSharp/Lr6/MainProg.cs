using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class MainProg
    {
        
        static void Main()
        {
            IaTPStudent std = new IaTPStudent();
            Console.WriteLine("Info about default student : ");
            Console.WriteLine(std);
            Console.WriteLine("\n");


            Console.WriteLine("Type info for new students:");
            IaTPStudent[] list = new IaTPStudent[2];
            IaTPStudent.SetArray(list);
            Console.WriteLine();
            for (int j = 0; j < list.Length; j++)
            {
                list[j].MassIndex();
            }


            IQualif action2 = new IaTPStudent();
            Student action1 = new Student();
            Console.WriteLine();
            action1.DiplomaType();
            action2.DiplomaType();

            action1.SetScholarship();
            action2.SetScholarship();

            Console.WriteLine();



            Console.WriteLine("Sorted by course list:");
            Array.Sort(list);
            foreach (IaTPStudent s in list)
            {
                Console.WriteLine(s);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Copy of the first student in the list:");
            IaTPStudent obj = (IaTPStudent)list[0].Clone();
            Console.WriteLine(obj);

            Console.ReadKey();
        }
    }
}
