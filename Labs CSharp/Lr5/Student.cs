using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class Student : Man
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
            return base.ToString()+";"+"Faculty: "+Faculty+ ";" +"Course: "+ Course + ";";
        }

        public override void DiplomaType()
        {
            Console.WriteLine("Your qualification is Engineer");
        }

    }
}
