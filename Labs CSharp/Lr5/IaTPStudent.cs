using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    enum SpecialtyName
    {
        IaTP=1,
        CSaN,
        ITS,
        ECS
    }

    public struct Discipline
    {
        public string DisciplineName { get; set; }
        public int Hours { get; set; }
    }

    class CompetenciesPerson:Student
  
    {
        public SpecialtyName  Specialty { get; set; }
        public string GroupNumber { get; set; }
        public string Qualification { get; set; }

        public Discipline dis;

        public CompetenciesPerson():base()
        {
            Specialty = SpecialtyName.IaTP;
            GroupNumber = "753503";
            dis.DisciplineName = "ISP";
            dis.Hours = 120;
            Qualification = "System Engineer";
            hobbies = new string[2];
            hobbies[0] = "Rubik's cubes solving";
            hobbies[1] = "Playing table tennis";
        }

        public override string ToString()
        {
            string str = " ";
            for (int i = 0; i < hobbies.Length; i++)
            {
                str = str + hobbies[i] + ";";
            }
            return base.ToString() + "Specialty: " + Specialty + ";" + "Group: " + GroupNumber + ";" + "Discipline: " + dis.DisciplineName + ";" + "Hours for input discipline: " + dis.Hours + ";" + "Students hobbies: " + str + "\n";
        } 

        public override void DiplomaType()
        {
            Console.WriteLine("Your qualification is {0}",Qualification);
        }

        
    }
}
