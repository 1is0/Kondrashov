using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class Student: Man, IStudentAttributes
    {
        public int Course { get; set; }
        public string Faculty { get; set; }

        public Student() : base()
        {
            Course = 3;
            Faculty = "FCSaN";
        }

        public override string ToString()
        {
            return base.ToString() + ";"+"\n" + "Faculty: " + Faculty + ";" + "Course: " + Course + ";"+"\n";
        }

        public override void DiplomaType()
        {
            Console.WriteLine("Your qualification is Engineer");
        }

        public override void SetScholarship()
        {
            Console.WriteLine("Your base scholarship is 77,80 Br");
        }
    }
}
