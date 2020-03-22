using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UnsafeCode
{
    class MyDllImport
    {
        [DllImport("DllForUnsafeCode.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int add(int a,int b);

        [DllImport("DllForUnsafeCode.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int sub(int a, int b);

        [DllImport("DllForUnsafeCode.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double Average(int n,double d1, double d2, double d3);



        public static void DllTreatment()
        {
            int a = 10, b = 20;
            int c=MyDllImport.add(a, b);
            Console.WriteLine("Dll Addition: {0}", c);

            int d=MyDllImport.sub(a, b);
            Console.WriteLine("Dll Substation: {0}", d);

            double cc1 = 10.0;
            double cc2 = 20.0;
            double av = MyDllImport.Average(3,cc1, cc2, 30.0);
            Console.WriteLine("Dll Averaging: {0}", av);
        }
    }
}
