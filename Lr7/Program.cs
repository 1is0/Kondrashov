using System;

namespace Laboratory7
{
    class Program
    {
        public static int CheckInt()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Incorrect input, please repeat: ");
            }
            return a;
        }

        public static string CheckDouble()
        {
            double a;
            string str = Console.ReadLine();
            while (!double.TryParse(str, out a))
            {
                Console.Write("Incorrect input, please repeat: ");
                str = Console.ReadLine();
            }
            return str;
        }

        public static int CheckNat()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Incorrect input, please repeat: ");
            }
            return a;
        }

        public static bool CheckFraction(string frac)
        {
            if (String.IsNullOrEmpty(frac))
            {
                return false;
            }
            for (int i = 0; i < frac.Length; i++)
            {
                if (i == 0 && frac[i] == '-')
                {
                    i++;
                }
                if (frac[i] == '/' && i != frac.Length - 1)
                {
                    i++;
                }
                if (frac[i] == '0'&& frac.Length==1)
                {
                    return false;
                }
                if (!char.IsDigit(frac[i]) || (frac[i] == '0' && i == frac.Length - 1 && frac[i - 1] == '/'))
                {
                    return false;
                }
            }
            return true;
        }

        public static string GetFraction()
        {
            string str = Console.ReadLine();
            while (!CheckFraction(str))
            {
                Console.Write("Incorrect input, repeat: ");
                str = Console.ReadLine();
            }
            return str;
        }
        static void Main()
        {
            Console.Write("Enter the rational number(xx,xx): ");
            var num1 = CheckDouble();

            RationalNumber RatNum1 = RationalNumber.GetNumberObjectFromString(num1);
            Console.WriteLine($"{RatNum1.ShowFull()}");

            Console.Write("Enter the fraction number(xx/xx): ");
            var num2 = GetFraction();

            RationalNumber RatNum2 = RationalNumber.GetFractionObjectFromString(num2);
            Console.WriteLine($"{RatNum2.ShowFull()}");

            Console.WriteLine("Operators overload: ");

            Console.WriteLine($">. {RatNum1.FractionString()} > {RatNum2.FractionString()} = " + (RatNum1 > RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} > {RatNum2.NumberString()} = " + (RatNum1 > RatNum2) + "\n");
            Console.WriteLine($"<. {RatNum1.FractionString()} < {RatNum2.FractionString()} = " + (RatNum1 < RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} < {RatNum2.NumberString()} = " + (RatNum1 < RatNum2) + "\n");
            Console.WriteLine($">=. {RatNum1.FractionString()} >= {RatNum2.FractionString()} = " + (RatNum1 >= RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} >= {RatNum2.NumberString()} = " + (RatNum1 >= RatNum2) + "\n");
            Console.WriteLine($"<=. {RatNum1.FractionString()} <= {RatNum2.FractionString()} = " + (RatNum1 <= RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} <= {RatNum2.NumberString()} = " + (RatNum1 <= RatNum2) + "\n");
            Console.WriteLine($"==. {RatNum1.FractionString()} == {RatNum2.FractionString()} = " + (RatNum1 == RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} == {RatNum2.NumberString()} = " + (RatNum1 == RatNum2) + "\n");
            Console.WriteLine($"!=. {RatNum1.FractionString()} != {RatNum2.FractionString()} = " + (RatNum1 != RatNum2));
            Console.WriteLine($"   {RatNum1.NumberString()} != {RatNum2.NumberString()} = " + (RatNum1 != RatNum2) + "\n");
            Console.WriteLine($"+. {RatNum1.FractionString()} + {RatNum2.FractionString()} = " + (RatNum1 + RatNum2).FractionString());
            Console.WriteLine($"   {RatNum1.NumberString()} + {RatNum2.NumberString()} = " + (RatNum1 + RatNum2).FractionString() + "\n");
            Console.WriteLine($"-. {RatNum1.FractionString()} - {RatNum2.FractionString()} = " + (RatNum1 - RatNum2).FractionString());
            Console.WriteLine($"   {RatNum1.NumberString()} - {RatNum2.NumberString()} = " + (RatNum1 - RatNum2).FractionString() + "\n");
            Console.WriteLine($"*. {RatNum1.FractionString()} * {RatNum2.FractionString()} = " + (RatNum1 * RatNum2).FractionString());
            Console.WriteLine($"   {RatNum1.NumberString()} * {RatNum2.NumberString()} = " + (RatNum1 * RatNum2).FractionString() + "\n");
            if (RatNum2 != 0)
            {
                Console.WriteLine($"/. {RatNum1.FractionString()} / {RatNum2.FractionString()} = " + (RatNum1 / RatNum2).FractionString());
                Console.WriteLine($"   {RatNum1.NumberString()} / {RatNum2.NumberString()} = " + (RatNum1 / RatNum2).NumberString() + "\n");
            }
        }
    }
}
